using Discord;
using Discord.Net;
using Discord.WebSocket;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Program;



namespace Commands.Ping;

public class Ping
{
    private readonly DiscordSocketClient _client = null!;
    public async Task Client_Ready(DiscordSocketClient _client)
    {
        ulong guildId = Convert.ToByte(Environment.GetEnvironmentVariable("GUILD_ID"));
        var guild = _client.GetGuild(guildId);
        
        var guildCommand = new SlashCommandBuilder();

        // Note: Names have to be all loweercase and match the regular expression
        guildCommand.WithName("first-command");

        // Descriptions can have a max length of 100
        guildCommand.WithDescription("This is my first guild slash command!");
        

        var globalCommand = new SlashCommandBuilder();
        globalCommand.WithName("first-global-command");
        globalCommand.WithDescription("This is my first global slash command");


        try
        {
            // Now that we have our builder, we can call the CreateApplicationCommandAsync method to make our slash command.
            await guild.CreateApplicationCommandAsync(guildCommand.Build());

            // With global commands we don't need the guild.
            await _client.CreateGlobalApplicationCommandAsync(globalCommand.Build());
            // Using the ready event is a simple implementation for the sake of the example. Suitable for testing and development.
            // For a production bot, it is recommended to only run the CreateGlobalApplicationCommandAsync() once for each command.
        }
        catch(HttpException exception)
        {
            // if out command was invalid, we should catch an HttpExeption. this exception contains the Discord error code, the request object that was sent,
            // the reason of the exception and a list of of errors to explain what went wrong with the request. You can serialize the Error field in the exception to get a visual of where you error is.
            var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);

            // You can send this error somewhere or just print it to the console.
            Console.WriteLine(json);
        }
    }
}