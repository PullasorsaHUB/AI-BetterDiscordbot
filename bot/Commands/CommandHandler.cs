using Discord.WebSocket;
using Program;
using System.Collections.Generic;




namespace Commands.CommandHandler;

public class Command_Handler
{
    private readonly DiscordSocketClient _client = null!;
    
    public Command_Handler(DiscordSocketClient client)
    {
        // Tänne lisätään siteen muita komenttoja mitä sitten tulee aikanaan että kaikki käy tämän kautta.
        _client = client;
    }
    public static async Task SlashCommandHandler(SocketSlashCommand command)
    {
        await command.RespondAsync($"You executed {command.Data.Name}");
    }
}