using System;
using System.Collections.Generic;

namespace IO_SubDirectories
{
    internal static class Program
    {
        private static string rootSearchDir = @"C:\Users\...";
        private static string[] extensionsToSearch = new string[] { "*.mp3" };

        private static void Main()
        {
            var fromToReplacements = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(" - ", "")
            };

            try
            {
                string[] TEST = GetFiles.AllByExtensions(rootSearchDir, extensionsToSearch);

                FilesRenamer.ReplaceByPatterns(fromToReplacements, TEST);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\r\n Done.");
            Console.ReadKey();
        }
    }
}
