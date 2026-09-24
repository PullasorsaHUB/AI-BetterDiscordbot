using Discord;
using Discord.WebSocket;
using System;
using Microsoft.Extensions.DependencyInjection;
using Discord.Rest;
using System.Diagnostics.Tracing;
using Newtonsoft.Json;
using System.Text.Json;
using DotNetEnv;
using Microsoft.Extensions.Configuration;
using Commands.Ping;
using Commands.CommandHandler;
using Null_Hood_BotManager;

namespace Program;
public class Program
{
    // Luodaan Discord Client
    private static DiscordSocketClient _client = null!;
    public static async Task Main()
    {
        Env.Load();
        _client = new DiscordSocketClient();

        _client.Log += Log;
        _client.Ready += OnReady;
        _client.Ready += Ping.Client_Ready;
        _client.SlashCommandExecuted += Command_Handler.SlashCommandHandler;

        var token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");
        Console.WriteLine($"Token pituus: {token?.Length ?? -1}");
        await _client.LoginAsync(TokenType.Bot,token);
        await _client.StartAsync();
        
        // Nämä pitää olla pois päätlä muuten botti ei toimi!!!!
        //var _Null_Hood = new Bot_Manager(_client);
        //await _Null_Hood.PingAsync();

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }


    private static Task Log(LogMessage log_msg)
    {
        Console.WriteLine(log_msg.ToString());
        return Task.CompletedTask;
    }
    private static Task OnReady()
    {
        Console.WriteLine($" Connected as {_client?.CurrentUser.Username}#{_client?.CurrentUser.Discriminator}");
        return Task.CompletedTask;
    }
}