using System;
using System.IO;
using HtmlAgilityPack;

namespace DoToKin
{
    internal static class Program
    {
        private const string addressConstant = "https://...";
        private static readonly string savePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DOWNLOADED.txt");

        private static void Main()
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
                var fs = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.Write);
                var sw = new StreamWriter(fs);
                sw.WriteLine(title);
                sw.WriteLine("\r\n ========================================================= \r\n");

                for (int i = 0; i < comments.Count - 1; i++)
                {
                    var comment = comments[i].NextSibling.InnerText.Split('\n');

                    foreach (var line in comment)
                    {
                        var aline = line.Trim();

                        if (!string.IsNullOrWhiteSpace(aline) && aline != "Ответить" && aline != "Поддержать")
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
