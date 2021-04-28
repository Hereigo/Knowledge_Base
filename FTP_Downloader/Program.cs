using System;
using System.IO;
using GIT_IGNORE;

namespace FTP_Downloader
{
    internal static class Program
    {
        private static Uri uriArch = new Uri(PASSWORDS.ftpPath);
        private static Uri uriDb = new Uri(PASSWORDS.ftpPathDb);

        private static void Main()
        {
            // Archiving previous :

            if (File.Exists(PASSWORDS.zipOutputDB))
            {
                string oldFile = PASSWORDS.tempPathToStore + PASSWORDS.zipOutputDB;
                if (File.Exists(oldFile))
                {
                    File.Delete(oldFile);
                }
                File.Move(PASSWORDS.zipOutputDB, oldFile);
            }

            if (File.Exists(PASSWORDS.zipOutput))
            {
                string oldFile = PASSWORDS.tempPathToStore + PASSWORDS.zipOutput;
                if (File.Exists(oldFile))
                {
                    File.Delete(oldFile);
                }
                File.Move(PASSWORDS.zipOutput, oldFile);
            }

            Console.WriteLine("\r\n - What would you like, my Lord? \r\n");

            string password = Console.ReadLine().Trim();

            FtpWorker ftp = new FtpWorker(password);
            Zipper zipper = new Zipper(password);

            string[] ftpFilesBak = ftp.GetFilesListByExt(uriDb, ".bak");

            string ftpFilesBakLast = string.Empty;

            foreach (string item in ftpFilesBak)
            {
                if (!File.Exists(item))
                {
                    ftp.DownloadFileFromFtp(item, uriDb, false);
                    ftpFilesBakLast = item;
                }
            }

            zipper.CompressFile(ftpFilesBakLast, PASSWORDS.zipOutputDB);

            string[] archivesList = ftp.GetFilesListByExt(uriArch, ".zip");

            if (archivesList.Length > 0)
            {
                string latestArchiveName = ftp.SelectLatestByNameFile(archivesList);

                ftp.DownloadFileFromFtp(latestArchiveName, uriArch, true);

                zipper.CompressFile(latestArchiveName, PASSWORDS.zipOutput);

                FileInfo archive = new FileInfo(PASSWORDS.zipOutput);

                if (archive.Exists)
                {
                    Console.WriteLine($"\r\nArchive Created. Size : {archive.Length / 1024} kb, Modified : {archive.LastWriteTime}");
                    Console.WriteLine("\r\nCheck downloaded file and press any key TO DELETE temporary files ...\r\n");
                    Console.ReadKey();
                    File.Delete(latestArchiveName);
                    ftp.DeleteFilesFromFtp(archivesList, uriArch);
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
