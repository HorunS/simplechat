using SimpleChat.Client;

var srv = new ChatService();

var client = new Client(srv);

await client.Start();

Console.ReadLine();
