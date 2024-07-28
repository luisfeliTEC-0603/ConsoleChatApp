
using System;
using System.Net.Sockets;
using System.Text;

namespace ChatApp
{
    public class Sender
    {
        private readonly string _ipAddress; // IP adress for connection -local-.
        private int _port; // Port to send the message. 

        public Sender(string ipAddress, int port) // Constructor. 
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public bool SendMessage(string message) // Method to send messages. 
        {
            try
            {
                TcpClient client = new TcpClient(); // Create a new TCP client.
                client.Connect(_ipAddress, _port); // Try to estrablish conection to listener. 
                NetworkStream stream = client.GetStream(); // Get the network stream for sending data.
                byte[] buffer = Encoding.UTF8.GetBytes(message); // Encode the message -byte array-.
                stream.Write(buffer, 0, buffer.Length); // Write the byte array into the network stream.

                // Close the TCP client, once the message is upload. 
                stream.Close();
                client.Close();

                return true;
            }
            catch(SocketException ex)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"SocketException: {ex.Message}"); // Handle exception when listener is not connected.
                Console.WriteLine(" ");

                return false;
            }
        }
    }
}
