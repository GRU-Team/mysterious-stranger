using Discord;
using Discord.Commands;
using Discord.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteriousStranger.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("Pong");
        }

        [Command("getAllGrid")]
        public async Task GetAllGrid()
        {
            string message = LettersGridHandler.GetGridInString();
            var msg = await ReplyAsync(message);
            LettersGridHandler.MessageWithGrid = msg;
        }

        [Command ("changeGrid")]
        public async Task ModifyLastMessage()
        {
            await Context.Client.CurrentUser.ModifyAsync(u => u.Username = "Mysterious Stranger");

           // var UserMessage = MessageExtensions 
        }


        [Command("W")]
        public async Task Move()
        {
            if (LettersGridHandler.MessageWithGrid != null)
            {
                LettersGridHandler.Init(20);
                await LettersGridHandler.MessageWithGrid.ModifyAsync(x =>
                x.Content = LettersGridHandler.GetGridInString());
            }
            else
            {
                await ReplyAsync("Вызови поле");
            }

        }
    }
}
