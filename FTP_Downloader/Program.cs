using System;
using System.IO;
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
                string latestFileName = FtpWorker.SelectFtpListLatestFile(filesList);

                FtpWorker.DownloadFileFromFtp(latestFileName, uri, credentials);

                Zipper.CompressFile(password, latestFileName, GIT_IGNORE.zipOutput);

                FileInfo archive = new FileInfo(GIT_IGNORE.zipOutput);

                if (archive.Exists)
                {
                    Console.WriteLine($"\r\nArchive Created. Size : {archive.Length / 1024} kb, Modified : {archive.LastWriteTime}");
                    Console.WriteLine("\r\nCheck downloaded file and press any key TO DELETE temporary files ...\r\n");
                    Console.ReadKey();
                    File.Delete(latestFileName);
                    FtpWorker.DeleteFilesFromFtp(filesList, uri, credentials);
                }
                else
                {
                    Console.WriteLine("WARNING! Archive not created!");
                }
            }

            Console.ReadKey();
        }
    }
}
