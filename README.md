# ConsoleChatApp

## Overview
_ConsoleChatApp_ is a basic instant messaging application developed using C# and the .NET 8 framework. 

## Requirements
- _**Operating System**_.: Windows, macOS, or Linux.
- _**.NET 8 SDK**_.: Ensure .NET 8 SDK is installed on your system.

## Functionality
### Run the Application
The application is executed from the terminal (PowerShell, Command Prompt, or Terminal). The following command starts the application, it can be run multiple instances to simulate multiple clients.
```sh
dotnet run ConsoleChatApp -port <listening-port>
```
### Sending Messages
When running the application, the user must enter the destination port. Once the connection is established, the user can write and send messages to the specified port.

It is important to note that messages that are successfully sent appear with a double check (✓ ✓) next to them. If the message is not sent, the exception will be generated in the user console, and double checks will not appear.

### Aditional Notes
This repository contains additional documents beyond the source code. These documents provide guidance on setting up Visual Studio Code (VSCode) for running C# projects. The setup instructions ensure that you have the necessary environment to compile and run the application smoothly.

The primary functionality of the application is implemented in the .cs files. These files contain the core logic for the chat client and handle the socket-based communication between clients.