using System.Threading.Channels;
using Discord.Commands;
using Discord.WebSocket;
using Discord;


namespace AIBot.Say;

public class SayModule : ModuleBase<SocketCommandContext>
{
    private static DiscordSocketClient _client = null!;
    [Command("Say")]
    public async Task Say_to_everybody(string msg)
    {
        await ReplyAsync(msg);
    }
}