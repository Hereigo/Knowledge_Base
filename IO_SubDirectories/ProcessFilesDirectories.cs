using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IO_SubDirectories
{
    public static class ProcessFilesDirectories
    {
        internal static string[] GetArrayByNames(string rootPath, string[] dirNamesToSearch, string[] skipDirectories)
        {
            List<string> foundDirectories = new List<string>();

            foreach (string everyDir in Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories))
            {
                string currentDirName = Path.GetFileName(everyDir);

                if (!skipDirectories.Contains(currentDirName) && dirNamesToSearch.Contains(currentDirName))
                {
                    foundDirectories.Add(everyDir);
                }
            }

            return foundDirectories.ToArray();
        }

        // string[] searchPatterns = { "*.mp3", "*.mp4", "*.avi" };

        internal static int CalcSizeOfFilesByTypes(string rootSearchDir, string[] searchPatterns)
        {
            return
                searchPatterns.AsParallel().SelectMany(
                        pattern => Directory.EnumerateFiles(rootSearchDir, pattern, SearchOption.AllDirectories))
                        .Sum(f => f.Length);
        }



        internal static void TEST(string path, string searchPattern)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            DirectoryInfo[] directories =
                di.GetDirectories(searchPattern, SearchOption.TopDirectoryOnly);

            FileInfo[] files =
                di.GetFiles(searchPattern, SearchOption.TopDirectoryOnly);
        }
    }
}
