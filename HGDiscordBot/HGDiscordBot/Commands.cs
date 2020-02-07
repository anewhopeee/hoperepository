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
        public async Task HelloCommand([Remainder]string args = null)
        {
            // initialize empty string builder for reply
            var sb = new StringBuilder();

            // splits the args into an array
            string[] SplittedArgs = args.Split(' '); 

            // get user info from the Context
            var user = Context.User;

            // build out the reply
            sb.AppendLine($"You are -> [{user}]");
            sb.AppendLine($"And your parsed arguments were {SplittedArgs[0]} and {SplittedArgs[1]}.");

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
            sb.AppendLine("?hello => Will display crazy Dev stuff or crash the bot");
            sb.AppendLine("?withdraw {Resource} {Amount} => Will send you resources from the alliance bank");
            /*
            sb.AppendLine("?withdrawToNationID {NationID} {Resource} {Amount} => Will send resources to the specified Nation");
            sb.AppendLine("?limits => Will display your Daily withdraw Limits");
            sb.AppendLine("?transactions => Will display your last withdraws");
            */
            
            await ReplyAsync(sb.ToString()); // send simple string reply
        }
        [Command("withdraw")]
        public async Task withdraw([Remainder]string args = null)
        {
            var user = Context.User.ToString();
            string[] SplittedArgs = args.Split(' ');
            if (SplittedArgs.GetLength(0) != 2 || Char.IsNumber(SplittedArgs[1], 3))
            {
                await ReplyAsync("Bad Arguments => ?withdraw {Resource} {Amount}.");
                return;
            }
            Int32 Amount = Convert.ToInt32(SplittedArgs[1]);
            Console.WriteLine($"{user} requested a withdraw of {SplittedArgs[0]} {SplittedArgs[1]}");
            string NationID = HGDiscordBot.CheckIfAllowedToWithdraw.ReturnNationIDIfUserIsValidAndDailyLimitsMatchRequest(user, SplittedArgs[0], Amount);

            switch (NationID)
            {
                case "No Match":
                    await ReplyAsync($"No Matching NationID to {user}.");
                    break;
                case "LimitBlock":
                    await ReplyAsync("You cannot withdraw more than your daily limit.");
                    break;
                case "ResourceError":
                    await ReplyAsync("The resource you are trying to withdraw doesnt exists. See ?resources for more Information.");
                    break;
                default:
                    HGDiscordBot.SendResourcesToNationID.SendResourcesWithAmountToNationID(NationID, SplittedArgs[0], Amount);
                    break;
            }
        }
    }
}
