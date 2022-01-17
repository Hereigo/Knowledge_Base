using System;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace CS_EXAMPLES
{
    internal static class DoToKin
    {
        private static readonly string[] excludedWords = new string[] { "Ответить", "Поддержать", "Відповісти", "Підтримати" };
        private static readonly string saveDir =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static void Test(string addressConstant)
        {
            Console.WriteLine("Wich address?");
            var address = Console.ReadLine();

            var html = !string.IsNullOrWhiteSpace(address) ? address : addressConstant;

            var web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var title = htmlDoc.DocumentNode.SelectSingleNode("//h1").InnerText;
            var htmlNode = htmlDoc.GetElementbyId("commentsList");
            var comments = htmlNode.ChildNodes;

            try
            {
                var fs = new FileStream(Path.Combine(saveDir, $"{title}.txt"), FileMode.OpenOrCreate, FileAccess.Write);
                var sw = new StreamWriter(fs);
                sw.WriteLine(title);
                sw.WriteLine("\r\n ========================================================= \r\n");

                for (int i = 0; i < comments.Count - 1; i++)
                {
                    var comment = comments[i].NextSibling.InnerText.Split('\n');

                    foreach (var line in comment)
                    {
                        var aline = line.Trim();

                        // TODO
                        // implement sort by time inMemoryDb

                        if (aline.Length > 2 && !excludedWords.Contains(aline))
                        {
                            sw.WriteLine(aline);
                        }
                    }
                    sw.WriteLine("\r\n");
                }

                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\r\n Done.");
        }
    }
}
