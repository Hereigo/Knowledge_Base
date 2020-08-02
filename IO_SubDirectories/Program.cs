using System;
using System.Collections.Generic;

namespace IO_SubDirectories
{
    internal static class Program
    {
        private const string projectToClean = @"\source\repos\" + "Testing_Labs";

        private static readonly string rootSearchDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private static readonly string[] extensionsToSearch = new string[] { "*.mp3" };

        private static readonly List<KeyValuePair<string, string>> fromToReplacements = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("", ""),
            new KeyValuePair<string, string>("", "")
        };

        private static void Main()
        {
            try
            {
                //string[] TEST = GetFiles.AllByExtensions(rootSearchDir, extensionsToSearch);
                // FilesRenamer.ReplaceSomeToAnother(fromToReplacements, TEST);
                // VS_Projects_Cleaner.CleanAll(projectToClean);

                Poligon.TestMe();

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
