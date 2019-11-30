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
        [Command("start")]
        public async Task StartGame()
        {
            await Context.Message.DeleteAsync();
            string message = LettersGridHandler.GetGridInString();
            var msg = await ReplyAsync(message);
            LettersGridHandler.MessageWithGrid = msg;
        }

        [Command ("changeGrid")]
        public async Task ModifyLastMessage()
        {
            await ReplyAsync("No");
        }


        [Command("W")]
        public async Task MoveUp()
        {
            if (LettersGridHandler.MessageWithGrid != null)
            {
                await Context.Message.DeleteAsync();
                LettersGridHandler.MoveUp();
                await LettersGridHandler.MessageWithGrid.ModifyAsync(x =>
                x.Content = LettersGridHandler.GetGridInString());
            }
            else
            {
                await ReplyAsync("Поле ещё не было представлено твоему взору...");
            }

        }

        [Command ("S")]
        public async Task MoveDown()
        {
            if (LettersGridHandler.MessageWithGrid != null)
            {
                await Context.Message.DeleteAsync();
                LettersGridHandler.MoveDown();
                await LettersGridHandler.MessageWithGrid.ModifyAsync(x =>
                x.Content = LettersGridHandler.GetGridInString());
            }
            else
            {
                await ReplyAsync("Поле ещё не было представлено твоему взору...");
            }
        }

        [Command("D")]
        public async Task MoveRight()
        {
            if (LettersGridHandler.MessageWithGrid != null)
            {
                await Context.Message.DeleteAsync();
                LettersGridHandler.MoveRight();
                await LettersGridHandler.MessageWithGrid.ModifyAsync(x =>
                x.Content = LettersGridHandler.GetGridInString());
            }
            else
            {
                await ReplyAsync("Поле ещё не было представлено твоему взору...");
            }
        }

        [Command("A")]
        public async Task MoveLeft()
        {
            if (LettersGridHandler.MessageWithGrid != null)
            {
                await Context.Message.DeleteAsync();
                LettersGridHandler.MoveLeft();
                await LettersGridHandler.MessageWithGrid.ModifyAsync(x =>
                x.Content = LettersGridHandler.GetGridInString());
            }
            else
            {
                await ReplyAsync("Поле ещё не было представлено твоему взору...");
            }
        }

        [Command("E")]
        public async Task ReadLetter()
        {
            await Context.Message.DeleteAsync();
            await ReplyAsync($"Найденное письмо гласит \"{LettersGridHandler.ReadMessage()}\"");
            
        }

        [Command("Q")]
        public async Task WriteMessage([Remainder] string message)
        {
            await Context.Message.DeleteAsync();
            LettersGridHandler.WriteMessage(message);
            await ReplyAsync($"Вы оставили свою записку здесь {Environment.NewLine}" +
                $"Она гласит \"{message}\"");
        }
    }
}
