using System;
using System.IO;
using System.Linq;
using System.Net;

namespace FTP_Downloader
{
    public static class FtpWorker
    {
        public static string GetFilesList(Uri remoteUri, NetworkCredential credentials)
        {
            string latestFileName = string.Empty;

            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{remoteUri}");
                request.Credentials = credentials;
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                // files list sorted descending :
                string[] filesList = names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                Array.Reverse(filesList);

                // select zip-file name from the latest file record :
                if (filesList.Length > 0)
                {
                    foreach (var item in filesList[0].Split(' '))
                    {
                        if (item.EndsWith(".zip"))
                        {
                            latestFileName = item;
                            break;
                        }
                    }
                }
                Console.WriteLine($"\r\nDirectory List Complete, status {response.StatusDescription}");
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }

            return latestFileName;
        }

        public static void DisplayFileFromServer(Uri remoteUri, string fileName, NetworkCredential credentials)
        {
            // The serverUri parameter should start with the ftp:// scheme.
            if (remoteUri.Scheme != Uri.UriSchemeFtp)
            {
                Console.WriteLine($"Not valid FTP url : {remoteUri}");
                return;
            }
            if (string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("No files to download!");
                return;
            }

            WebClient myWebClient = new WebClient
            {
                Credentials = credentials
            };

            try
            {
                Console.WriteLine($"Downloading File \"{remoteUri}\" .......\n\n");

                myWebClient.DownloadFile(remoteUri + fileName, fileName);

                Console.WriteLine($"File {fileName} Successfully Downloaded.");
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}