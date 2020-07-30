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

                //foreach (var item in TEST)
                //{
                //    Console.WriteLine(item);
                //}

                // FilesRenamer.ReplaceSomeToAnother(fromToReplacements, TEST);


                VS_Projects_Cleaner.CleanAll(projectToClean);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // TEST =======================

            //List<KeyValuePair<int, int>> identityResult = new List<KeyValuePair<int, int>>
            //{
            //    new KeyValuePair<int, int>(20,6),
            //    new KeyValuePair<int, int>(20,7),
            //    new KeyValuePair<int, int>(20,6),
            //    new KeyValuePair<int, int>(20,8),
            //    new KeyValuePair<int, int>(20,6),
            //    new KeyValuePair<int, int>(20,9),
            //    new KeyValuePair<int, int>(20,8),
            //    new KeyValuePair<int, int>(20,7)
            //};

            //StringBuilder sb = new StringBuilder("SELECT * FROM table WHERE Test=True ");

            //bool isExpectedFound = false;


            //HashSet<KeyValuePair<int, int>> aaa = new HashSet<KeyValuePair<int, int>>();

            //foreach (var item in identityResult)
            //{
            //    if (!aaa.Contains(item))
            //    {
            //        aaa.Add(item);

            //        // Upload Expected TradeFlow delete TF for ALL Countries in Uploaded Month!
            //        // thus we need At-Price "Month-Year" for ALL Countries.

            //        if (true) //item.Status == 2)
            //        {
            //            if (!isExpectedFound)
            //                sb.Append(" AND (");
            //            else
            //                sb.Append(" OR ");

            //            isExpectedFound = true;

            //            sb.Append("(Year=").Append(item.Key)
            //                .Append(" AND Month=").Append(item.Value).Append(") ");
            //        } 
            //    }
            //}

            //sb.Append(")");

            //Console.WriteLine(sb.ToString());



            Console.WriteLine("\r\n Done.");
            Console.ReadKey();
        }
    }
}
