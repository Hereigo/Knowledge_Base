using System;
using System.IO;
using System.Net;

namespace FTP_Downloader
{
    internal static class Program
    {
        private static Uri uriArch = new Uri(GIT_IGNORE.ftpPath);
        private static Uri uriDb = new Uri(GIT_IGNORE.ftpPathDb);

        private static void Main()
        {
            Console.WriteLine("Write your wishes :\r\n");

            string password = Console.ReadLine().Trim();

            NetworkCredential credentials = new NetworkCredential(GIT_IGNORE.ftpUser, password);

            string[] backupsList = FtpWorker.GetFilesListByExt(uriDb, ".bak", credentials);

            foreach (var item in backupsList)
            {
                if (!File.Exists(item))
                {
                    FtpWorker.DownloadFileFromFtp(item, uriDb, credentials, false);

                    Console.WriteLine($"{item} downloaded.");

                    Zipper.CompressFile(password, item, GIT_IGNORE.zipOutputDB);
                }
            }

            string[] archivesList = FtpWorker.GetFilesListByExt(uriArch, ".zip", credentials);

            if (archivesList.Length > 0)
            {
                string latestArchiveName = FtpWorker.SelectLatestByNameFile(archivesList);

                FtpWorker.DownloadFileFromFtp(latestArchiveName, uriArch, credentials, true);

                Zipper.CompressFile(password, latestArchiveName, GIT_IGNORE.zipOutput);

                FileInfo archive = new FileInfo(GIT_IGNORE.zipOutput);

                if (archive.Exists)
                {
                    Console.WriteLine($"\r\nArchive Created. Size : {archive.Length / 1024} kb, Modified : {archive.LastWriteTime}");
                    Console.WriteLine("\r\nCheck downloaded file and press any key TO DELETE temporary files ...\r\n");
                    Console.ReadKey();
                    File.Delete(latestArchiveName);
                    FtpWorker.DeleteFilesFromFtp(archivesList, uriArch, credentials);
                }
                else
                {
                    Console.WriteLine("WARNING! Archive not created!");
                }
            }

            Console.WriteLine("\r\nAll tasks finished.");
            Console.ReadKey();
        }
    }
}
