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
using AIBot;
using Discord.Commands;
using System.Reflection;

namespace Program;
public class Program
{
    // Luodaan Discord Client
    private static DiscordSocketClient _client = null!;
    private static CommandService _commands;
    private static readonly char _prefix = '!';
    private static ulong _channelId;
    public static async Task Main()
    {
        Env.Load();
        _channelId = ulong.Parse(Environment.GetEnvironmentVariable("TEST"));
        _client = new DiscordSocketClient(Config.Get_Config());
        _commands = new CommandService();

        _client.Log += Log;
        _client.Ready += OnReady;
        _client.MessageReceived += HandleMessage;
        
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);

        var token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");
        await _client.LoginAsync(TokenType.Bot,token);
        await _client.StartAsync();
        
        // Block this task until the program is closed.
        await Task.Delay(-1);
    }

    private static async Task HandleMessage(SocketMessage rawMsg)
    {

        if(rawMsg is not SocketUserMessage msg) return;
        if(msg.Channel.Id != _channelId) return;
        if(msg.Author.IsBot) return;

        int argPos = 0;
        
        // Tässä tarkastetaan että onko viestissä meidän Prefix eli "!".
        if(!msg.HasCharPrefix(_prefix, ref argPos)) return;

        var context = new SocketCommandContext(_client, msg);
        await _commands.ExecuteAsync(context, argPos, null);
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