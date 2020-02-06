using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGBot
{
    class Program
    {
        public DiscordSocketClient Client;
        public CommandHandler Handler;
        static void Main(string[] args) => new Program().Start().GetAwaiter().GetResult();
        public async Task Start()
        {
            Client = new DiscordSocketClient();

            Handler = new CommandHandler();

            await Client.LoginAsync(Discord.TokenType.Bot, "Your Token here(We have to implement a way to get the token for a file)", true);

            await Client.StartAsync();

            await Handler.Install(Client);

            Client.Ready += Client_Ready;

            await Task.Delay(-1);
        }

        private async Task Client_Ready()
        {
            Console.WriteLine("The bot is online.");
            return;
        }

    }
}

