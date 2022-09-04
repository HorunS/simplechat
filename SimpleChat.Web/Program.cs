using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleChat.Api;
using SimpleChat.Api.Managers;
using SimpleChat.Core;
using SimpleChat.Core.Managers;
using SimpleChat.Web;
using SimpleChat.Web.Hubs;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddSingleton<IDataClient, MemoryDataClient>();

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<SimpleChatHub>("/chat");

app.Run();
