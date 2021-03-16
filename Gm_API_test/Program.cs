using System;

namespace Gm_API_test
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                //string base64Encoded = "YmFzZTY0IGVuY29kZWQgc3RyaW5n";

                string base64Encoded = "0K3RhS4uLg0KD";

                byte[] data = System.Convert.FromBase64String(base64Encoded);

                string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);

                Console.WriteLine(base64Decoded);

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