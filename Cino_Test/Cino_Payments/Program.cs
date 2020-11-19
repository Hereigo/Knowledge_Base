using System;
using System.IO;

namespace Cino_Payments
{
    class Program
    {
        private static Uri uriArch = new Uri(GIT_IGNORE.ftpPath);
        private static Uri uriDb = new Uri(GIT_IGNORE.ftpPathDb);

        private static void Main()
        {
            // Archiving previous :

//            if (File.Exists(GIT_IGNORE.zipOutputDB))
//            {
//                string oldFile = GIT_IGNORE.tempPathToStore + GIT_IGNORE.zipOutputDB;
//                if (File.Exists(oldFile))
//                {
//                    File.Delete(oldFile);
//                }
//                File.Move(GIT_IGNORE.zipOutputDB, oldFile);
//            }
//
//            if (File.Exists(GIT_IGNORE.zipOutput))
//            {
//                string oldFile = GIT_IGNORE.tempPathToStore + GIT_IGNORE.zipOutput;
//                if (File.Exists(oldFile))
//                {
//                    File.Delete(oldFile);
//                }
//                File.Move(GIT_IGNORE.zipOutput, oldFile);
//            }

            Console.WriteLine("\r\n - What would you like, my Lord? \r\n");

            string magicWord = Console.ReadLine()?.Trim();

            FtpWorker ftp = new FtpWorker(magicWord);
            Zipper zipper = new Zipper(magicWord);

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

            if (!string.IsNullOrEmpty(ftpFilesBakLast))
            {
                zipper.CompressFile(ftpFilesBakLast, GIT_IGNORE.zipOutputDB);
            }

            string[] archivesList = ftp.GetFilesListByExt(uriArch, ".zip");

            if (archivesList.Length > 0)
            {
                string latestArchiveName = ftp.SelectLatestByNameFile(archivesList);

                ftp.DownloadFileFromFtp(latestArchiveName, uriArch, true);

                zipper.CompressFile(latestArchiveName, GIT_IGNORE.zipOutput);

                FileInfo archive = new FileInfo(GIT_IGNORE.zipOutput);

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
