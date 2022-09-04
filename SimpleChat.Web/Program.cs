using SimpleChat.Api.Managers;
using SimpleChat.Core.Managers;
using SimpleChat.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddTransient<IUserManager, UserManager>();

var app = builder.Build();

app.MapHub<SimpleChatHub>("/chat");

app.Run();
