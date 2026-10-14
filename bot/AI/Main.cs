using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace AIBot;
public class Main: ModuleBase<SocketCommandContext>
{
    private static readonly DiscordSocketClient _client = null!;
    private static CommandService _commands;
    private static char _prefix = '!';
    private readonly ulong _channelId = Convert.ToUInt64(Environment.GetEnvironmentVariable("TEST"));

    private static async Task HandleMessage(SocketMessage rawMsg , char _prefix)
    {
        // TODO 1: muuta rawMsg -> SocketUserMessage (vihje: "as"-avainsana tai "is"-tarkistus)
        // TODO 2: ohita botit
        // TODO 3: tarkista prefix. Etsi methodia HasCharPrefix, se ottaa '!' ja ref int argPos
        // TODO 4: luo SocketCommandContext (parametrit: client ja viesti)
        // TODO 5: _commands.ExecuteAsync(context, argPos, services)

        if(rawMsg is not SocketUserMessage msg) return;
        if(msg.Author.IsBot) return;

        int argPos = 0;
        
        // Tässä tarkastetaan että onko viestissä meidän Prefix eli "!".
        if(!msg.HasCharPrefix(_prefix, ref argPos)) return;

        var context = new SocketCommandContext(_client, msg);
        await _commands.ExecuteAsync(context, argPos, null);
    }
}