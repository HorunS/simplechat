﻿using SimpleChat.Client;

var srv = new ChatService();
await srv.Start("testuser");

await srv.SendMessage("Hello darkness, my old friend");

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.ReadLine();
