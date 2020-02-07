using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGBot
{
    public class Commands : ModuleBase
    {
        [Command("ping")]
        public async Task Ping()
        {
            var msg = await ReplyAsync("***Calculating ping***");

            await ReplyAsync($"Pong! ***{msg.Timestamp.Millisecond - DateTime.Now.Millisecond}***ms");


            await msg.DeleteAsync();
        }

        [Command("hello")]
        public async Task HelloCommand()
        {
            Console.WriteLine("Someone requested the hello command");
            // initialize empty string builder for reply
            var sb = new StringBuilder();

            // get user info from the Context
            var user = Context.User;
            var args = Context.Message.Content;
            // build out the reply
            sb.AppendLine($"You are -> [{user}]");
            sb.AppendLine($"And your parsed arguments were {args}");

            // send simple string reply
            await ReplyAsync(sb.ToString());
        }

        [Command("help")]
        public async Task help()
        {
            Console.WriteLine("Someone requested the help command");
            // initialize empty string builder for reply
            var sb = new StringBuilder();
            // build out the reply
            sb.AppendLine("Here are all the commands you can use with the HGBot");
            sb.AppendLine("?ping => Will return the ping in ms");
            sb.AppendLine("?hello => Will display crasy Dev stuff or crash the bot");
            sb.AppendLine("?withdraw {Resource} {Amount} => Will send you resources from the alliance");
            /*
            sb.AppendLine("?withdrawToNationID {NationID} {Resource} {Amount} => Will send resources to the specified Nation");
            sb.AppendLine("?limits => Will display your Daily withdraw Limits");
            sb.AppendLine("?transactions => Will display your last withdraws");
            */
            
            await ReplyAsync(sb.ToString()); // send simple string reply
        }
        [Command("withdraw")]
        public async Task withdraw()
        {
            var user = Context.User;
            Console.WriteLine($"{user} requested a withdraw");

        }
    }
}
