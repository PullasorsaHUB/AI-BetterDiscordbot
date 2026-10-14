

using Discord.Commands;
using Discord.WebSocket;

namespace AIBot.Ping;
public class PingModule : ModuleBase<SocketCommandContext>
{
    // TODO: attribuutti + metdoi joka vastaa "Pong!"
    [Command("Ping")]
    public async Task PingAsync()
    {
        await ReplyAsync("Pong 🏓");
    }
}