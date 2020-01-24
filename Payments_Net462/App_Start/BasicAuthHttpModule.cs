using System;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace Payments_Net462.App_Start
{
    public class BasicAuthHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private static bool CheckPassword(string username, string password)
        {
            bool result;

            using (SHA1Managed sha = new SHA1Managed())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(username + password));

                string TEST = Convert.ToBase64String(hash);

                result = Convert.ToBase64String(hash) == GIT_IGNORE.Variables.paymentsNet462_BaseAuthStr;
            }
            return result;
        }

        private static void AuthenticateUser(string credentials)
        {
            try
            {
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));
                int separator = credentials.IndexOf(':');
                string name = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);

                if (CheckPassword(name, password))
                {
                    GenericIdentity identity = new GenericIdentity(name);
                    SetPrincipal(new GenericPrincipal(identity, null));
                }
                else
                {
                    HttpContext.Current.Response.StatusCode = 401;
                }
            }
            catch (FormatException)
            {
                HttpContext.Current.Response.StatusCode = 401;
            }
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            HttpRequest request = HttpContext.Current.Request;

            string authHeader = request.Headers["Authorization"];

            if (authHeader != null)
            {
                AuthenticationHeaderValue authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            HttpResponse response = HttpContext.Current.Response;

            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", "My Realm"));
            }
        }

        public void Dispose()
        {
        }
    }
}