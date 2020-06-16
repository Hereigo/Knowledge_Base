using System;
using System.Net;

namespace FTP_Downloader
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Write your password to download :\r\n");

            string password = Console.ReadLine().Trim();

            NetworkCredential credentials = new NetworkCredential(GIT_IGNORE.ftpUser, password);

            Uri uri = new Uri(GIT_IGNORE.ftpPath);

            string[] filesList = FtpWorker.GetZipFilesList(uri, credentials);

            if (filesList.Length < 1)
            {
                Console.WriteLine("No files to download!");
            }
            else
            {
                string latestFile = FtpWorker.SelectFtpListLatestFile(filesList);

                FtpWorker.DownloadFileFromFtp(latestFile, uri, credentials);

                Console.WriteLine("\r\nCheck downloaded file and press any key to clean Server ...\r\n");
                Console.ReadKey();

                FtpWorker.DeleteFilesFromFtp(filesList, uri, credentials);
            }

            Console.ReadKey();
        }
    }
}
