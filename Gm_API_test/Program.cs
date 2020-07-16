using System;

namespace Gm_API_test
{
    internal static class Program
    {
        private static void Main()
        {
            // 
            try
            {
                //string base64Encoded = "YmFzZTY0IGVuY29kZWQgc3RyaW5n";

                string base64Encoded = "0K3RhS4uLg0KD";

                byte[] data = System.Convert.FromBase64String(base64Encoded);

                string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);

                Console.WriteLine(base64Decoded);

                //byte[] data = System.Convert.FromBase64String(base64Encoded);

                //Console.WriteLine(Encoding.Default.GetString(data));
                //Console.WriteLine(Encoding.Unicode.GetString(data));
                //Console.WriteLine(Encoding.UTF8.GetString(data));
                //Console.WriteLine(Encoding.UTF7.GetString(data));
                //Console.WriteLine(Encoding.UTF32.GetString(data));
                //Console.WriteLine(Encoding.BigEndianUnicode.GetString(data));
                //Console.WriteLine(Encoding.ASCII.GetString(data));
                //Console.WriteLine(Encoding.GetEncoding("iso-8859-1").GetString(data));
                ////Console.WriteLine(Encoding.GetEncoding(1251).GetString(data));
                ////Console.WriteLine(Encoding.GetEncoding(1252).GetString(data));

                //int cnt = 0;

                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.Default.GetString(data));
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.Unicode.GetString(data));
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.UTF8.GetString(data));
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.UTF7.GetString(data));
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.UTF32.GetString(data));
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.BigEndianUnicode.GetString(data));
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.ASCII.GetString(data));
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.GetEncoding("iso-8859-1").GetString(data));
                ////File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.GetEncoding(1251).GetString(data));
                ////File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.GetEncoding(1252).GetString(data));

                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.Default.GetString(data), Encoding.UTF8);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.Unicode.GetString(data), Encoding.UTF8);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.UTF8.GetString(data), Encoding.UTF8);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.UTF7.GetString(data), Encoding.UTF8);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.UTF32.GetString(data), Encoding.UTF8);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.BigEndianUnicode.GetString(data), Encoding.UTF8);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.ASCII.GetString(data), Encoding.UTF8);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.GetEncoding("iso-8859-1").GetString(data), Encoding.UTF8);


                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.Default.GetString(data), Encoding.Default);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.Unicode.GetString(data), Encoding.Default);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.UTF8.GetString(data), Encoding.Default);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.UTF7.GetString(data), Encoding.Default);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.UTF32.GetString(data), Encoding.Default);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.BigEndianUnicode.GetString(data), Encoding.Default);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.ASCII.GetString(data), Encoding.Default);
                //File.WriteAllText($"AAA_{cnt++}.TXT", Encoding.GetEncoding("iso-8859-1").GetString(data), Encoding.Default);

                //File.WriteAllText("AAA.TXT", base64Decoded, Encoding.Default); //  GetEncoding("iso-8859-1"));

                //File.WriteAllText("AAA.TXT", data, Encoding.UTF8); //  GetEncoding("iso-8859-1"));

                //Console.WriteLine(base64Decoded);

                //Client.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();

            Console.Read();
        }
    }
}