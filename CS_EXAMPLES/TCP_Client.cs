using System;
using System.Net.Http;
using System.Net.Sockets;

namespace CS_EXAMPLES
{
    internal class TCP_Client
    {
        public static void Test()
        {
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect("http://192.168.0.197", 27777);

                NetworkStream netStream = tcpClient.GetStream();

                string response = "Slava Ukraini!!!";

                byte[] data = System.Text.Encoding.UTF8.GetBytes(response);

                netStream.Write(data, 0, data.Length);

                Console.WriteLine(response);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                tcpClient.Close();
            }

            Console.WriteLine("Done.");

            Console.ReadKey();
        }
    }
}
