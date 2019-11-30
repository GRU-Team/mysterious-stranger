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
    internal sealed class DiscordBot
    {
        private DiscordSocketClient client;
        private CommandService commandService;
        private IServiceProvider serviceProvider;
        private DiscordBotSettings settings;

        internal DiscordBot()
        {
            this.settings = new DiscordBotSettings();
            this.settings.Token = Config.appSettings.Settings["Token"].Value;
            this.settings.Prefix = Config.appSettings.Settings["Prefix"].Value;
        }

        internal async Task RunBotAsync()
        {
            client = new DiscordSocketClient();
            commandService = new CommandService();
            serviceProvider = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commandService)
                .BuildServiceProvider();

            client.Log += DiscordClientLog_Log;

            await RegisterCommandAsync();

            await client.LoginAsync(TokenType.Bot, settings.Token);

            await client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task RegisterCommandAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await commandService.AddModulesAsync(Assembly.GetEntryAssembly(),
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
                var result = await commandService.ExecuteAsync(context, argPos, serviceProvider);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);

            }
        }
    }
}
