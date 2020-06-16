using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;

namespace FTP_Downloader
{
    public static class FtpWorker
    {
        internal static string[] GetZipFilesList(Uri remoteUri, NetworkCredential credentials)
        {
            List<string> filesList = new List<string>();

            // The serverUri parameter should start with the ftp:// scheme.
            if (remoteUri.Scheme != Uri.UriSchemeFtp)
            {
                Console.WriteLine($"Not valid FTP url : {remoteUri}");
            }
            else
            {
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

                    // select zip-file name from the latest file record :
                    foreach (var line in names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray())
                    {
                        foreach (var item in line.Split(' '))
                        {
                            if (item.EndsWith(".zip"))
                            {
                                filesList.Add(item);
                            }
                        }
                    }

                    Console.WriteLine($"\r\nDirectory List Complete, status {response.StatusDescription}");
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return filesList.ToArray();
        }

        internal static void DeleteFilesFromFtp(string[] filesList, Uri remoteUri, NetworkCredential credentials)
        {
            foreach (var file in filesList)
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{remoteUri}{file}");
                    request.Credentials = credentials;
                    request.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Console.WriteLine($"{file} - Delete status: {response.StatusDescription}");
                    response.Close();
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        internal static void DownloadFileFromFtp(string fileName, Uri remoteUri, NetworkCredential credentials)
        {
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

                Process.Start(fileName);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        internal static string SelectFtpListLatestFile(string[] filesList)
        {
            string latestFileName = string.Empty;

            if (filesList.Length > 0)
            {
                // files list sorted descending :
                Array.Reverse(filesList);

                latestFileName = filesList[0];
            }
            return filesList[0];
        }
    }
}