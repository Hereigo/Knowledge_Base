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
    internal static class Program
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "Gmail API .NET Quickstart";

        private static void Main()
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

            //IList<Message> msgs = request.Execute().Messages;

            //if (msgs?.Count > 0)
            //{
            //    int cnt = 1;
            //    foreach (var item in msgs)
            //    {
            //        Console.WriteLine(
            //            $"{cnt++}\r\n{item.Id}\r\n");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No msgs found.");
            //}


            var TEST = Class2.GetMessage(service, "me", "1733490e3f3410a3");

            Console.WriteLine(TEST.Payload.Body);
            Console.WriteLine(TEST.Payload.Body.Data);
            Console.WriteLine(TEST.Payload.Filename);
            Console.WriteLine(TEST.Payload.Parts.Count);
            Console.WriteLine(TEST.Payload.Parts[0].MimeType);
            Console.WriteLine(TEST.Payload.Parts[1].Filename);


            Console.Read();
        }
    }
}