

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
        private static async Task HandleMessage(SocketMessage rawMsg)
    {
        // TODO 1: muuta rawMsg -> SocketUserMessage (vihje: "as"-avainsana tai "is"-tarkistus)
        // TODO 2: ohita botit
        // TODO 3: tarkista prefix. Etsi methodia HasCharPrefix, se ottaa '!' ja ref int argPos
        // TODO 4: luo SocketCommandContext (parametrit: client ja viesti)
        // TODO 5: _commands.ExecuteAsync(context, argPos, services)
    }

}