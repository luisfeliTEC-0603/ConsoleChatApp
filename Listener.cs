
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatApp
{
    public class Listener
    {
        private readonly int _port;

        public Listener(int port) // Constructor.
        {
            _port = port; // Assigns the port value with the given argument during obj inst.  
        }

        public void Start() // Method to start the listener. 
        {
            TcpListener listener = new TcpListener(IPAddress.Any, _port); // New TcpListener obj that listens on any IP address on the specified port.
            listener.Start(); // Start listening for client requests.

            while (true) // Loop to keep listening for incoming connections. 
            {
                TcpClient client = listener.AcceptTcpClient(); // Accepts clients with TCP network services. 
                NetworkStream network = client.GetStream(); // Gets the network stream -messages- for reading and writing.

                byte[] buffer = new byte[1024]; // Buffers incoming data.
                int bytesRead = network.Read(buffer, 0, buffer.Length); // Counts the read data.
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead); // Converts byte array to string. 
                Console.WriteLine(message); // Displays the decode in the listener's Console. 

                // Close the stream and client connection. 
                network.Close();
                client.Close();
            }
        }
    }
}
