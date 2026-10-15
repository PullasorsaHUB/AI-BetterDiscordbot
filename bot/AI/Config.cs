using Discord.WebSocket;

namespace AIBot;
class Config
{
    public static DiscordSocketConfig Get_Config()
    {
        var config = new DiscordSocketConfig()
        {
            GatewayIntents = Discord.GatewayIntents.AllUnprivileged | Discord.GatewayIntents.MessageContent
        };
        return config;
    }
}