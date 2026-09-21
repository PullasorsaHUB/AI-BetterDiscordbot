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




public class Program
{
    // Luodaan Discord Client
    private static DiscordSocketClient _client;
    public static async Task Main()
    {
        Env.Load();
        _client = new DiscordSocketClient();
        _client.Log += Log;

        var token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");
        Console.WriteLine($"Token pituus: {token?.Length ?? -1}");
        await _client.LoginAsync(TokenType.Bot,token);
        await _client.StartAsync();
        

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }


    private static Task Log(LogMessage log_msg)
    {
        Console.WriteLine(log_msg.ToString());
        return Task.CompletedTask;
    }
}