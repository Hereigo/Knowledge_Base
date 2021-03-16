using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Gm_API_test
{
    public static class Client
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "Gmail API .NET Quickstart";

        /// <summary>
        /// Retrieve a Message by ID.
        /// </summary>
        /// <param name="service">Gmail API service instance.</param>
        /// <param name="userId">User's email address. The special value "me"
        /// can be used to indicate the authenticated user.</param>
        /// <param name="messageId">ID of Message to retrieve.</param>
        private static Message GetMessage(GmailService service, String userId, String messageId)
        {
            try
            {
                return service.Users.Messages.Get(userId, messageId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return null;
        }

        public static void Run()
        {

            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Gmail API service.
            GmailService service = new GmailService(
                new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

            // Define parameters of request.
            // UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List("me");
            request.MaxResults = 10;

            // List labels.
            // IList<Label> labels = request.Execute().Labels;
            // Console.WriteLine("Labels:");

            // if (labels != null && labels.Count > 0)
            // {
            //     foreach (var labelItem in labels)
            //     {
            //         Console.WriteLine("{0}", labelItem.Name);
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("No labels found.");
            // }

            Console.WriteLine(request.Execute().Messages.Count);

            IList<Message> msgs = request.Execute().Messages;

            if (msgs?.Count > 0)
            {

                string lastMsg = string.Empty;

                int cnt = 1;
                foreach (var item in msgs)
                {
                    Console.WriteLine(
                        $"{cnt++}\r\n{item.Id}\r\n");

                    lastMsg = item.Id.ToString();
                }


                var TEST = GetMessage(service, "me", lastMsg);

                Console.WriteLine(TEST.Payload.Body);
                Console.WriteLine(TEST.Payload.Body.Data);
                Console.WriteLine(TEST.Payload.Filename);
                Console.WriteLine(TEST.Payload.Parts.Count);
                Console.WriteLine(TEST.Payload.Parts[0].Filename);
                Console.WriteLine(TEST.Payload.Parts[0].Body.Data);
                Console.WriteLine(TEST.Payload.Parts[1].Body.Data);

                // Base64decode :

                string base64Encoded = "0K3RhS4uLg0KD"; // TEST.Payload.Parts[0].Body.Data.ToString();

                //var TET = Base64UrlDecode(base64encoded);

                //string base64Decoded;
                byte[] data = Convert.FromBase64String(base64Encoded);
                //base64Decoded = System.Text.Encoding.ASCII.GetString(data);

                // var message_data = TEST.Payload.Parts[0].Body.Data;
                // var json_data = JSON.parse(message_data.to_json)
                // var decoded_message = Base64.urlsafe_decode64(json_data["body"]["data"])


            }
            else
            {
                Console.WriteLine("No msgs found.");
            }
        }

    }
}
