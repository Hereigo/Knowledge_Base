using System.Xml.Xsl;

namespace XSLTransformations
{
    static class Program
    {
        private static void Main()
        {
            string baseDir = System.Environment.CurrentDirectory;
            XslTransform xslt = new XslTransform();
            xslt.Load(baseDir + "\\Transformer.xslt");
            xslt.Transform(baseDir + "\\InputFile.xml", baseDir + "\\OutputFile.xml");
        }
    }
}
