using System;
using System.Net.Sockets;
using System.Text;

namespace yomayo_client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";

            Console.Write("Nickname: ");
            string userName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Ur nick {userName}. Type 'exit' to quit.");

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{userName}: ");
                    string message = Console.ReadLine();
                    Console.ResetColor();

                    
                    if (string.IsNullOrEmpty(message) || message.ToLower() == "exit")
                    {
                        Console.WriteLine("adios amigo");
                        break;
                    }

                    using (TcpClient client = new TcpClient("127.0.0.1", 8888))
                    {
                        NetworkStream stream = client.GetStream();

                        string fullMessage = $"{userName}: {message}";
                        byte[] data = Encoding.UTF8.GetBytes(fullMessage);
                        stream.Write(data, 0, data.Length);

                        byte[] responseBuffer = new byte[1024];
                        int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
                        string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(response);
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
            }
        }
    }
}