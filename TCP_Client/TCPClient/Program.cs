using System;
using System.Net.Sockets;
using System.Net.Http;

namespace TCPClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string requestMessage = "Please process this message!";
            string responseMessage = sendMessage(requestMessage);
            Console.WriteLine(responseMessage);
        }

        public static string sendMessage(string message)
        {
            string response = "";
            try
            {
                TcpClient client = new TcpClient("192.168.0.197", 27777); // Create a new connection  
                client.NoDelay = true; // please check TcpClient for more optimization
                                       // messageToByteArray- discussed later
                byte[] messageBytes = messageToByteArray(message);

                using (NetworkStream stream = client.GetStream())
                {
                    stream.Write(messageBytes, 0, messageBytes.Length);

                    // Message sent!  Wait for the response stream of bytes...
                    // streamToMessage - discussed later
                    response = streamToMessage(stream);
                }
                client.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return response;
        }
        static System.Text.Encoding encoding = Encoding.UTF8;
        private static byte[] messageToByteArray(string message)
        {
            // get the size of original message
            byte[] messageBytes = encoding.GetBytes(message);
            int messageSize = messageBytes.Length;
            // add content length bytes to the original size
            int completeSize = messageSize + 4;
            // create a buffer of the size of the complete message size
            byte[] completemsg = new byte[completeSize];

            // convert message size to bytes
            byte[] sizeBytes = BitConverter.GetBytes(messageSize);
            // copy the size bytes and the message bytes to our overall message to be sent 
            sizeBytes.CopyTo(completemsg, 0);
            messageBytes.CopyTo(completemsg, 4);
            return completemsg;
        }

        private static string streamToMessage(Stream stream)
        {
            // size bytes have been fixed to 4
            byte[] sizeBytes = new byte[4];
            // read the content length
            stream.Read(sizeBytes, 0, 4);
            int messageSize = BitConverter.ToInt32(sizeBytes, 0);
            // create a buffer of the content length size and read from the stream
            byte[] messageBytes = new byte[messageSize];
            stream.Read(messageBytes, 0, messageSize);
            // convert message byte array to the message string using the encoding
            string message = encoding.GetString(messageBytes);
            string result = null;
            foreach (var c in message)
                if (c != '\0')
                    result += c;

            return result;
        }
    }
}



