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
            // initialize empty string builder for reply
            var sb = new StringBuilder();

            // get user info from the Context
            var user = Context.User;

            // build out the reply
            sb.AppendLine($"You are -> []");
            sb.AppendLine("I must now say, World!");

            // send simple string reply
            await ReplyAsync(sb.ToString());
        }
    }
}
