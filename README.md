# Simple console Client to Server chat

A lightweight console-based messenger built with **C#** using **TCP Sockets**. 
This project demonstrates the core concepts of networking, data streams (`NetworkStream`), and basic client-server architecture.

## Tech Stack
* **Language:** C#
* **Platform:** .NET Framework / .NET Core
* **Protocol:** TCP 

## How to Run?
1. Clone the repository to your local machine.
2. Open the solution (`.sln`) in Visual Studio.
3. Start the **Server** project first. It will enter "listening" mode.
4. Start the **Client** project.
5. Enter your nickname and start chatting!

> **Note:** To chat over a real network (not just localhost), replace `127.0.0.1` in the Client code with the Server's actual IP address.
