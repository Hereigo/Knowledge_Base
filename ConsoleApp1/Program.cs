using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //string base64Encoded = "YmFzZTY0IGVuY29kZWQgc3RyaW5n";

                string base64Encoded = "0K3RhS4uLg0KD000000000000000";

                byte[] data = System.Convert.FromBase64String(base64Encoded);

                string base64Decoded = System.Text.Encoding.Unicode.GetString(data);

                File.WriteAllText(DateTime.Now.ToString("HHmmss") + ".txt", base64Decoded, Encoding.ASCII);
                System.Threading.Thread.Sleep(2000);
                File.WriteAllText(DateTime.Now.ToString("HHmmss") + ".txt", base64Decoded, Encoding.UTF8);
                System.Threading.Thread.Sleep(2000);
                File.WriteAllText(DateTime.Now.ToString("HHmmss") + ".txt", base64Decoded, Encoding.BigEndianUnicode);
                System.Threading.Thread.Sleep(2000);
                File.WriteAllText(DateTime.Now.ToString("HHmmss") + ".txt", base64Decoded, Encoding.UTF32);
                System.Threading.Thread.Sleep(2000);
                File.WriteAllText(DateTime.Now.ToString("HHmmss") + ".txt", base64Decoded, Encoding.Unicode);
                System.Threading.Thread.Sleep(2000);
                File.WriteAllText(DateTime.Now.ToString("HHmmss") + ".txt", base64Decoded, Encoding.UTF7);

                Console.WriteLine(base64Decoded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
