using System.IO;

namespace IO_SubDirectories
{
    internal static class FilesRenamer
    {
        internal static void ReplaceByPatterns(string[] from, string[] to, string[] files)
        {
            if (from.Length != to.Length)
            {
                System.Console.WriteLine("Replace Collection FROM & TO must be the same length!");
            }
            else
            {
                foreach (var file in files)
                {
                    if (File.Exists(file))
                    {
                        string inFileName = Path.GetFileName(file);

                        string inFileFullPath = Path.GetFullPath(file);

                        string inFilePath = inFileFullPath.Substring(0, inFileFullPath.IndexOf(inFileName));

                        string outFileName = inFileName;

                        for (int i = 0; i < from.Length; i++)
                        {
                            outFileName = outFileName.Replace(from[i], to[i]);
                        }

                        if (inFileName != outFileName)
                        {
                            File.Move(inFileFullPath, inFilePath + outFileName);
                        }
                    }
                }
            }
        }
    }
}
