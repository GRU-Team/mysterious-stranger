using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace MysteriousStranger
{
    class Program
    {
        static void Main(string[] args) 
        {
            Config.LoadConfigFile();
            DiscordBot bot = new DiscordBot();
            bot.RunBotAsync().GetAwaiter().GetResult();
        }
    }
}
