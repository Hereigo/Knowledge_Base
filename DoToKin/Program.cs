using HtmlAgilityPack;

internal static class DoToKin
{
    private const string _addressConstant = ""; // "https://..../"

    private const string _commentsTag = "commentsList";

    private static readonly char[] notAllowerInFileName = new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };

    private static readonly string[] excludedWords = new string[] { "Ответить", "Поддержать", "Відповісти", "Підтримати" };

    private static readonly string saveDir =
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

    public static void Main()
    {
        Console.WriteLine("Wich address?");
        var address = Console.ReadLine();

        var html = !string.IsNullOrWhiteSpace(address) ? address : _addressConstant;
        var web = new HtmlWeb();
        var htmlDoc = web.Load(html);
        var pageTitle = htmlDoc.DocumentNode.SelectSingleNode("//h1").InnerText;

        pageTitle = ValidateTitle(pageTitle);
        try
        {
            var htmlNode = htmlDoc.GetElementbyId(_commentsTag);
            var comments = htmlNode.ChildNodes;

            var fs = new FileStream(Path.Combine(saveDir, $"{pageTitle}.txt"), FileMode.OpenOrCreate, FileAccess.Write);
            var sw = new StreamWriter(fs);
            sw.WriteLine(string.IsNullOrEmpty(address) ? _addressConstant : address);
            sw.WriteLine("\r\n" + pageTitle + "\r\n ========================================================= \r\n\r\n");

            for (int i = 0; i < comments.Count - 1; i++)
            {
                foreach (var line in comments[i].NextSibling.InnerText.Split('\n'))
                {
                    var aline = line.Trim();
                    if (aline.Length > 2 && !excludedWords.Contains(aline))
                    {
                        sw.WriteLine(aline);
                    }
                }
                sw.WriteLine("\r\n");
            }
            sw.Close();
            fs.Close();
            Console.WriteLine("\r\n Done.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadLine();
    }

    private static string ValidateTitle(string title)
    {
        string validTitle = "ERROR_TITLE_!!!";

        if (!string.IsNullOrWhiteSpace(title))
        {
            foreach (var notAllowedChar in notAllowerInFileName)
            {
                validTitle = title.Replace(notAllowedChar, '#');
            }
        }
        return validTitle;
    }
}