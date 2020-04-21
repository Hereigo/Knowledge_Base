using System;
using System.IO;

namespace IO_SubDirectories
{
    internal static class Program
    {
        private static void Main()
        {
            string rootPathToSearch = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                @"\source\repos\" + "FAKE_PROJECT";

            string[] directoryNames = { "bin", "obj" };

            string[] directoriesToSkip = { ".git" };

            Func<string[]> GetDirs = () => Directory.Exists(rootPathToSearch)
                ? ProcessFilesDirectories.GetArrayByNames(rootPathToSearch, directoryNames, directoriesToSkip)
                : new string[] { "No one found." };

            string[] mp3files = ProcessFilesDirectories.GetFilesMp3(rootPathToSearch);



            foreach (var item in GetDirs()) // mp3files)
            {
                Console.WriteLine(item);
            }

            string[] from = { "" };
            string[] into = { "" };

            // FilesRenamer.ReplaceByPatterns(from, into, mp3files);

            Console.WriteLine("\r\n Done.");
            Console.ReadKey();
        }
    }
}
