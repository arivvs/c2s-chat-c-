using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace yomayo_serv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "server";
            string myName = "admin"; // You can change the server's name here

            TcpListener server = new TcpListener(IPAddress.Any, 8888);
            server.Start();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("All started");
            Console.ResetColor();

            while (true)
            {
                using (TcpClient client = server.AcceptTcpClient())
                {
                    string remoteIp = client.Client.RemoteEndPoint.ToString();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"[LOG]: Connected ip {remoteIp}");
                    Console.ResetColor();

                    NetworkStream stream = client.GetStream();

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string incomingData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n[{DateTime.Now:HH:mm}] {incomingData}");
                    Console.ResetColor();

                    Console.Write("Want to ans? (y/n): ");

                    
                    while (true)
                    {
                        ConsoleKey key = Console.ReadKey(true).Key;

                        if (key == ConsoleKey.Y)
                        {
                            Console.WriteLine("y");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write($"{myName}: ");
                            string response = Console.ReadLine();

                            string fullResponse = $"{myName}: {response}";
                            byte[] responseData = Encoding.UTF8.GetBytes(fullResponse);
                            stream.Write(responseData, 0, responseData.Length);
                            Console.ResetColor();
                            break;
                        }
                        else if (key == ConsoleKey.N)
                        {
                            Console.WriteLine("n");
                            Console.WriteLine("\nYou ignored");
                            byte[] silent = Encoding.UTF8.GetBytes("You were ignored");
                            stream.Write(silent, 0, silent.Length);
                            break;
                        }
                        
                    }
                }
            }
        }
    }
}