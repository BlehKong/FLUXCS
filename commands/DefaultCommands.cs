using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using FLUX.data;
using Newtonsoft.Json;

namespace FLUX.commands
{
    public class DefaultCommands
    {
        [Command("spam")]
        [Description("Spam a mentioned user.")]
        public async Task Spam(CommandContext ctx, 
            [Description("The user you want to spam.")] DiscordMember user, 
            [Description("The amount of times to spam.")] int amount,
            [Description("The message you want to spam.")] params string[] content)
        {
            await ctx.Message.DeleteAsync();
            for(var i = 0; i < amount; i++)
            {
                await user.SendMessageAsync(string.Join(" ", content));
            }
        }

        [Command("cat")]
        [Description("Sends a random image of a cat.")]
        public async Task Cat(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            var url = "http://aws.random.cat/meow";

            var json = Utils.GetSerializedJson<JsonData>(url);
            var embed = new DiscordEmbedBuilder
            {
                ImageUrl = $"{json.Result.Cat}"
            };
            await ctx.Channel.SendMessageAsync(embed: embed.Build());
        }

    }
}
