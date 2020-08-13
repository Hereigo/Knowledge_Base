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
            Console.WriteLine("\r\n - What would you like, my lord? \r\n");

            string password = Console.ReadLine().Trim();

            NetworkCredential credentials = new NetworkCredential(GIT_IGNORE.ftpUser, password);

            foreach (string item in FtpWorker.GetFilesListByExt(uriDb, ".bak", credentials))
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

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\r\nAll tasks finished.");
            Console.ReadKey();

            // Temporary moving :

            if (File.Exists(GIT_IGNORE.zipOutputDB))
            {
                string oldFile = GIT_IGNORE.tempPathToStore + GIT_IGNORE.zipOutputDB;
                if (File.Exists(oldFile))
                {
                    File.Delete(oldFile);
                }
                File.Move(GIT_IGNORE.zipOutputDB, oldFile);
            }

            if (File.Exists(GIT_IGNORE.zipOutput))
            {
                string oldFile = GIT_IGNORE.tempPathToStore + GIT_IGNORE.zipOutput;
                if (File.Exists(oldFile))
                {
                    File.Delete(oldFile);
                }
                File.Move(GIT_IGNORE.zipOutput, oldFile);
            }
        }
    }
}
