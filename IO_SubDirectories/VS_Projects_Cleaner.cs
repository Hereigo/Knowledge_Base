using System;
using System.IO;

namespace IO_SubDirectories
{
    internal static class VS_Projects_Cleaner
    {
        internal static void CleanAll()
        {
            bool notFinished = true;

            while (notFinished)
            {
                Console.WriteLine("Input path to project to be cleared :");
                string rootPathToSearch = Console.ReadLine();

                if (!Directory.Exists(rootPathToSearch))
                {
                    Console.WriteLine($"Not found! - {rootPathToSearch}");
                    break;
                }
                else
                {
                    string[] dirNamesToFind = { "bin", "obj", "packages", ".vs" };
                    string[] dirNameToSkip = { ".git" };

                    string[] GetDirsByNames() => Directory.Exists(rootPathToSearch)
                        ? ProcessFilesDirectories.GetArrayByNames(rootPathToSearch, dirNamesToFind, dirNameToSkip)
                        : Array.Empty<string>();

                    //string[] mp3files = ProcessFilesDirectories.GetFilesMp3(rootPathToSearch);

                    foreach (var item in GetDirsByNames()) // mp3files)
                    {
                        // TOD :
                        // REFACTORE - EXTRACT :
                        string prevDirNameOnly = Path.GetFileName(Path.GetDirectoryName(item));
                        string lastDirNameOnly = Path.GetFileName(item);

                        //string newPath = $"{whereToMove}\\{prevDirNameOnly}_{lastDirNameOnly}".Replace(' ', '_').Replace(".vs", "_vs");
                        //Console.WriteLine(newPath);

                        try
                        {
                            // Directory.Move(item, newPath);

                            Console.WriteLine(item);

                            Directory.Delete(item, true);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    notFinished = false;
                }
            }
        }
    }
}
