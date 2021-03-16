using System.Text.RegularExpressions;

namespace AngularJS_ASPnet48_XML.Helpers
{
    public static class CustomHtmlHelpers
    {
        public static string RemoveHTMLTags(string value)
        {
            Regex regex = new Regex("\\<[^\\>]*\\>");
            return regex.Replace(value, string.Empty);
        }
    }
}