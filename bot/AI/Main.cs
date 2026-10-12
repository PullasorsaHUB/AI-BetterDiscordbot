using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace AIBot;
public class Main: ModuleBase<SocketCommandContext>
{
    private readonly DiscordSocketClient _client = null!;
    private readonly char _prefix = '!';
    private readonly ulong _channelId = Convert.ToByte(Environment.GetEnvironmentVariable("TEST"));
    
    public Main(DiscordSocketClient client)
    {
        _client = client;
    }
    [Command("ping")]
    public async Task PingAsync()
    {
        await ReplyAsync("Pong 🏓"); 
    }
}