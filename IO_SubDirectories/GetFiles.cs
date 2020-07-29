using System.Collections.Generic;
using System.IO;

namespace IO_SubDirectories
{
    internal static class GetFiles
    {
        internal static string[] AllByExtensions(string rootSearchDir, string[] extensionsToSearch)
        {
            List<string> foundFiles = new List<string>();

            if (extensionsToSearch.Length > 0)
            {
                for (int i = 0; i < extensionsToSearch.Length; i++)
                {
                    if (extensionsToSearch[i].StartsWith("*."))
                    {
                        foundFiles.AddRange(    // Search files recursively.
                            Directory.EnumerateFiles(rootSearchDir, extensionsToSearch[i], SearchOption.AllDirectories)
                            //.Where(f => f.EndsWith(".csproj", System.StringComparison.OrdinalIgnoreCase)
                            // || f.EndsWith(".config", System.StringComparison.OrdinalIgnoreCase)
                            // )
                            //.ToArray();
                            );
                    }
                }
            }
            return foundFiles.ToArray();
        }

        //internal static string[] GetAllExtensions(string rootSearchDir)
        //{

        //}
    }
}
