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
            SymbolMap.LoadSymbols();
            DiscordBot bot = new DiscordBot();

            LettersGridHandler.Init(
                Convert.ToInt32(
                    Config.appSettings.Settings["LetterGridSize"].Value));
            Console.WriteLine(LettersGridHandler.GetGridInString());

            bot.RunBotAsync().GetAwaiter().GetResult();
        }
    }
}
