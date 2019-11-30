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
    internal sealed class DiscordBot : IBot
    {
        private DiscordSocketClient client;
        private CommandService discordCommandService;
        private IServiceProvider serviceProvider;

        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient();
            discordCommandService = new CommandService();
            serviceProvider = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(discordCommandService)
                .BuildServiceProvider();

            string token = "NjUwMjk2NTkyNjU3NTQ3Mjc0.XeJSig.iZ0-UtH3DRnOrTgelOtdZj1vo0M";

            client.Log += DiscordClientLog_Log;

            await RegisterCommandAsync();

            await client.LoginAsync(TokenType.Bot, token);

            await client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task RegisterCommandAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await discordCommandService.AddModulesAsync(Assembly.GetEntryAssembly(),
                serviceProvider);
        }

        private Task DiscordClientLog_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(client, message);
            if (message.Author.IsBot) return;

            int argPos = 0;
            if (message.HasStringPrefix("!", ref argPos))
            {
                var result = await discordCommandService.ExecuteAsync(context, argPos, serviceProvider);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);

            }
        }
    }
}
