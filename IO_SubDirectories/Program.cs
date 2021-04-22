using System;
using System.Collections.Generic;

namespace IO_SubDirectories
{
    internal static class Program
    {
        private const string projectToClean = @"\source\repos\" + " ... ";
        private static readonly string rootSearchDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static readonly string rootPathToSearch = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
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
                Console.WriteLine("Select a Number:\r\n" +
                    "1 - Clear 'bin', 'obj', 'packages' folders fron your Project.\r\n" +
                    "2 - ... not implemented yet...\r\n" +
                    "\r\n" +
                    "or press any key to exit.");

                var select = Console.ReadLine();

                if(byte.TryParse(select, out byte number))
                {
                    switch(number)
                    {
                        case (1):
                            VS_Projects_Cleaner.CleanAll();
                            break;
                        default:
                            Console.WriteLine("Sorry. Not implemented yet.");
                            break;
                    }
                }

                // string[] TEST = GetFiles.AllByExtensions(rootSearchDir, extensionsToSearch);
                // 
                // FilesRenamer.ReplaceSomeToAnother(fromToReplacements, TEST);

                // Poligon.TEST_RUN();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\r\n Done.");
            Console.ReadKey();
        }
    }
}
