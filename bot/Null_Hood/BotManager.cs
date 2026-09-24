using Discord;
using Discord.Commands;
using Discord.WebSocket;



namespace Null_Hood_BotManager;

public class Bot_Manager : ModuleBase<SocketCommandContext>
{
    private readonly DiscordSocketClient _client = null!;
    private readonly char _prefix = '!';
    private readonly ulong _channelId = Convert.ToByte(Environment.GetEnvironmentVariable("TEST"));
    
    public Bot_Manager(DiscordSocketClient client)
    {
        _client = client;
    }
    [Command("ping")]
    public async Task PingAsync()
    {
        await ReplyAsync("Pong 🏓"); 
    }
}