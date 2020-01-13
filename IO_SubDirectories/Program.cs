using System;

namespace IO_SubDirectories
{
    internal static class Program
    {
        private static void Main()
        {
            const string rootPathToSearch = @"C:\Users\Hereigo\";

            string[] directoryNames = { "bin", "obj" };

            string[] directoriesToSkip = { ".git" };

            string[] dirs = ProcessFilesDirectories.GetArrayByNames(rootPathToSearch, directoryNames, directoriesToSkip);

            string[] mp3files = ProcessFilesDirectories.GetFilesMp3(rootPathToSearch);



            foreach (var item in mp3files)
            {
                Console.WriteLine(item);
            }

            string[] from = { "" };
            string[] into = { "" };

            FilesRenamer.ReplaceByPatterns(from, into, mp3files);

            Console.WriteLine("\r\n Done.");
            Console.ReadKey();
        }
    }
}
