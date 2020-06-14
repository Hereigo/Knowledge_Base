using System;
using System.Net;
using GIT_IGNORE;

namespace FTP_Downloader
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Write your password to download :\r\n");

            var password = Console.ReadLine().Trim();

            var credentials = new NetworkCredential(Variables.ftpUser, password);

            var uri = new Uri(Variables.ftpPath);

            var fileName = FtpWorker.GetFilesList(uri, credentials);

            FtpWorker.DisplayFileFromServer(uri, fileName, credentials);

            Console.ReadKey();
        }
    }
}
