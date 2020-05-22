
var ValidXMLChars = new Regex("[\u0009\u000a\u000d\u0020-\uD7FF\uE000-\uFFFD]");

// filters control characters but allows only properly-formed surrogate sequences
private static Regex _invalidXMLChars = new Regex(
    @"(?<![\uD800-\uDBFF])[\uDC00-\uDFFF]|[\uD800-\uDBFF](?![\uDC00-\uDFFF])|[\x00-\x08\x0B\x0C\x0E-\x1F\x7F-\x9F\uFEFF\uFFFE\uFFFF]",
    RegexOptions.Compiled);

// removes any unusual unicode characters that can't be encoded into XML
public static string RemoveInvalidXMLChars(string text)
{
    if (string.IsNullOrEmpty(text)) return "";
    return _invalidXMLChars.Replace(text, "");
}

// Replace Hexadecimal back to original string text

public XmlDocument GetXml(string text)
{
    XElement xElement = new XElement("RootNode");
    xElement.Add(new XElement("title", SanitizeHexaDecimalSymbol(text));
    var xmldoc = new XmlDocument();
    xmldoc.LoadXml(xElement.Tostring());
}

private static string SanitizeHexaDecimalSymbol(string txt)
{
    string regEx = @"[\x00-\x08\x0B\x0C\x0E-\x1F\x26]";
    return Regex.Replace(text, regEx, "", RegexOptions.Compiled);
}

// The following regex will only match printable text

string PrintableOnlyChars  = new Regex(@"[^\x00\x08\x0B\x0C\x0E-\x1F]*");

// The following Regex will find non-printable characters

string NonPrintableChar  = new Regex(@"[\x00\x08\x0B\x0C\x0E-\x1F]");