using System.Linq;
using System.Collections.Generic;
using System;
using System.IO;

namespace CS_EXAMPLES
{
    internal class FileRenamer
    {
        const string dirsPathSeparator = "/"; // Unix!!!
        const string searchPattern = "*";
        const string excludeDirName = "Music";
        static readonly string rootDir = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

        public static void Test()
        {
            var allDirsToProc = new string[] { rootDir }
            .Concat(
                Directory.GetDirectories(rootDir, searchPattern, SearchOption.AllDirectories)
                ).ToArray();

            List<string> files = new List<string>();

            foreach (var item in allDirsToProc)
                files.AddRange(Directory.GetFiles(item));

            foreach (var item in files)
            {
                var fi = new FileInfo(item);
                var fn = fi.Name;
                var path = fi.DirectoryName;
                var pathParts = path.Split(dirsPathSeparator);

                // File.Copy(item)
                System.Console.WriteLine($"{item} ===> {pathParts[pathParts.Length - 1]} - {fn}");
            }
        }
    }
}
