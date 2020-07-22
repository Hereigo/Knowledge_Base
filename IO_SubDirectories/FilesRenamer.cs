using System.Collections.Generic;
using System.IO;

namespace IO_SubDirectories
{
    internal static class FilesRenamer
    {
        internal static void ReplaceByPatterns(List<KeyValuePair<string, string>> fromToReplacements, string[] filesToRename)
        {
            foreach (var file in filesToRename)
            {
                if (File.Exists(file))
                {
                    string inFileName = Path.GetFileName(file);

                    string inFileFullPath = Path.GetFullPath(file);

                    string inFilePath = inFileFullPath.Substring(0, inFileFullPath.IndexOf(inFileName));

                    string outFileName = inFileName;

                    for (int i = 0; i < fromToReplacements.Count; i++)
                    {
                        outFileName = outFileName.Replace(fromToReplacements[i].Key, fromToReplacements[i].Value);
                    }

                    // TODO :
                    // Add validation asking HERE !

                    if (inFileName != outFileName)
                    {
                        File.Move(inFileFullPath, inFilePath + outFileName);
                    }
                }
            }
        }
    }
}
