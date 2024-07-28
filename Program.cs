
using System;
using System.IO;
using System.Reflection;

namespace ChatApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = GetFileName(); // Get the file name. 

            if (args.Length != 3 || args[1] != "-port" || args[0] != fileName) // Validates the arguments given. 
            {
                Console.WriteLine("Usage.: dotnet run <project-name> -port <listening-port>"); // Print usage instructions. 
                return;
            }

            if (!int.TryParse(args[2], out int port) || port < 5000) // Converts the third command-line argument to an int and validates the code.
            {
                Console.WriteLine("Invalid port.: Try a port greater than or equal to 5000."); // Print an error message.
                return;
            }
            else
            {
                Console.WriteLine($"Connection established on port {args[2]}..."); // Print a success message.
            }

            Console.Clear(); // Clears the Terminal.

            // Asks for input -Username-.
            Console.WriteLine("Username.: ");  
            string userName = Console.ReadLine();

            Task.Run(() => new Listener(port).Start()); // New task to listen for incoming messages.

            Console.WriteLine("Establish connection with port: ");
            if (!int.TryParse(Console.ReadLine(), out int destPort) || destPort < 5000) // Converts the given port to an int and validates the code.
            {
                Console.WriteLine("Invalid port.: Try a port greater than or equal to 5000."); // Print an error message.
                return;
            }
            else
            {
                Console.WriteLine("Connection Established...");
                Console.WriteLine("_");
            }

             // Create a new Sender obj with the specified IP address and destination port.
             // IP(127.0.0.1) -local communication within the same machine-.
            var sender = new Sender("127.0.0.1", destPort);

            while (true) // Loop
            {
                string message = Console.ReadLine(); // Type Message. 
                ClearCurrentConsoleLine(); // funct. Clear current line. 
                bool recipient = sender.SendMessage($"\t<{userName}>: {message}"); // Send Message with Sender obj method. 
                if (recipient)
                {
                    Console.WriteLine($"\t<{userName}>: {message} ✓✓"); // Prints the sent message in user's console and confirms the sending.
                    Console.Beep(); // Important !!!! ....Beep 
                }
                else
                {
                    Console.WriteLine($"\t<{userName}>: {message}"); // Prints the sent message in user's console, without confirmation.
                }
            }
        }

        public static string GetFileName()
        {
            string currentFilePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath; // Get the file path.
            string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath); // Get the file name without the extension.
            return currentFileName; // Return name.
        }

        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;  // Get the current cursor position -line number- in the console.
            Console.SetCursorPosition(0, currentLineCursor - 1); // Move the cursor to the start of the current line.
            Console.Write(new string(' ', Console.WindowWidth)); // Clear the line.
            Console.SetCursorPosition(0, currentLineCursor - 1);
        }
    }
}
