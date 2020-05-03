using System;
using System.IO;

namespace IO_SubDirectories
{
    internal static class Program
    {
        private static void Main()
        {
            string whereToMove = "C:\\Recycle.bin";

            string rootPathToSearch = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\source\repos\" + "FAKE_PROJECT";

            string[] dirNamesToFind = { "bin", "obj", "packages", ".vs" };

            string[] dirNameToSkip = { ".git" };

            string[] GetDirsByNames() => Directory.Exists(rootPathToSearch)
                ? ProcessFilesDirectories.GetArrayByNames(rootPathToSearch, dirNamesToFind, dirNameToSkip)
                : new string[] { "No one found." };


            //string[] mp3files = ProcessFilesDirectories.GetFilesMp3(rootPathToSearch);

            foreach (var item in GetDirsByNames()) // mp3files)
            {

                // TOD :
                // REFACTORE - EXTRACT :
                string prevDirNameOnly = Path.GetFileName(Path.GetDirectoryName(item));
                string lastDirNameOnly = Path.GetFileName(item);

                string newPath = $"{whereToMove}\\{prevDirNameOnly}_{lastDirNameOnly}".Replace(' ', '_');


                Console.WriteLine(newPath);

                // Directory.Move(item, newPath);

                //Directory.Delete(item, true);


            }

            string[] from = { "" };
            string[] into = { "" };

            // FilesRenamer.ReplaceByPatterns(from, into, mp3files);

            Console.WriteLine("\r\n Done.");
            Console.ReadKey();
        }
    }
}
