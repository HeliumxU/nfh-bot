/*
|---------- WARNING ----------|
|                             |
| Do Not Read This Code.      |
| It Will Be Painful To Read. |
| You May Want To Die.        |
| It Is Awful.                |
|                             |
|---------- WARNING ----------|
*/

//*-------------------------*\\
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Discord;
using Discord.Commands;

using IronOcr;
//*-------------------------*\\

namespace NFH_Bot.Core.Commands
{
    public class Command1 : ModuleBase<SocketCommandContext>
    {
        // HELP COMMAND, SIMPLE \\
        //*----------------------------------------------------------------------------------------------------*\\
        [Command("Help"), Alias("help", "commands", "Commands"), Summary("Help Command")]
        public async Task HelpCommand1()
        {
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithAuthor("Commands List", Context.User.GetAvatarUrl());
            Embed.WithColor(255, 223, 0);
            Embed.WithFooter("(c) 2018 - Encore#1965", Context.Guild.Owner.GetAvatarUrl());
            Embed.WithDescription("&Help - Displays All Avalible Commands. \n" +
                                  "&Ping - Ping & Pong Commands, respectively. \n" +
                                  "&Helloworld - A simple hello world command. \n" +
                                  "&Credits - Displays bot credits. \n" +
                                  "&ReadImage - Will read an image and paste the text from said image. \n" +
                                  //"& \n" + - Add more commands! - In case I want to die, remember to check if they're OVER 2K characters.
                "Feel free to take contact for bug reports & requests!");
            Embed.WithCurrentTimestamp();

            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }
        //*----------------------------------------------------------------------------------------------------*\\




        // STOP COMMAND \\
        //*----------------------------------------------------------------------------------------------------*\\
        [Command("Stop"), Alias("stop", "Quit", "quit", "Exit", "exit"), Summary("Command for exiting the program gracefully")]
        public async Task Stopme()
        {
            if (!(Context.User.Id == 168071466137419777))
            {
                await Context.Channel.SendMessageAsync(":x: !Error! - You are not a bot moderator!");
                return;
            }


            await Context.Channel.SendMessageAsync("Goodbye, friends.");
            System.Environment.Exit(0);
        }

        //*----------------------------------------------------------------------------------------------------*\\


        [Command("Timetest"), Alias("timetest", "Time", "time"), Summary("What is the time?")] // Helpful for OoS setups that cause artifacting
        public async Task Timetester()

        {
            await Context.Channel.SendMessageAsync("The time is: " + DateTime.Now);
        }



        // HELLO WORLD, SIMPLE \\
        //*----------------------------------------------------------------------------------------------------*\\
        [Command("Hello"), Alias("Helloworld", "hello", "helloworld"), Summary("Hello World Command")]          
        public async Task HelloWorld()                                                                          
        {                                                                                                       
            await Context.Channel.SendMessageAsync("Hello World!");                                             
        }                                                                                                       
        //*----------------------------------------------------------------------------------------------------*\\





        // PING PONG COMMAND, SIMPLE \\
        //*----------------------------------------------------------------------------------------------------*\\
        [Command("Ping"), Alias("ping"), Summary("Ping Pong Command - Ping side")]                              
        public async Task Ping()                                                                                
        {                                                                                                       
            await Context.Channel.SendMessageAsync("Pong!");                                                    
        }                                                                                                       
                                                                                                                
        [Command("Pong"), Alias("pong"), Summary("Ping Pong Command - Pong Side")]                              
        public async Task Pong()                                                                                
        {                                                                                                       
            await Context.Channel.SendMessageAsync("Ping!");                                                    
        }                                                                                                       
        //*----------------------------------------------------------------------------------------------------*\\





        // CREDITS COMMAND, SIMPLE \\
        //*----------------------------------------------------------------------------------------------------*\\
        [Command("credits"), Alias("Credits", "Creator", "creator", "Madeby", "madeby", "creds", "Creds", "whois", "Whois"), Summary("Bot Creator Credits")]
        public async Task Credits()
        {
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithAuthor("Encore", Context.User.GetAvatarUrl());
            Embed.WithColor(255, 223, 0);
            Embed.WithFooter("(c) 2018 - Encore#1965", Context.Guild.Owner.GetAvatarUrl());
            Embed.WithDescription("**Bot Created by me, in C#** \n" +
                "Here's a link to my Steam profile: \n" +
                "__https://steamcommunity.com/id/heliumx_9to5/__ \n" +
                "Twitter: __https://www.twitter.com/Encore45158090/__ \n" +
                "Feel free to take contact for bug reports & requests!");
            Embed.WithCurrentTimestamp();

            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }
        //*----------------------------------------------------------------------------------------------------*\\





        //*----------------------------------------------------------------------------------------------------*\\
        [Command("Embedtest"), Alias("embed", "Embed", "embedtest"), Summary("IO EmbedTest")]
        public async Task Embed([Remainder]string Input1 = "None")
        {
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithColor(255, 223, 0);
            Embed.WithFooter("(c) 2018 - Encore#1965", Context.Guild.Owner.GetAvatarUrl());
            Embed.WithDescription("Embedtest - What will we use this command for? \n" +
                                  "Good question- what do you say user?");
            Embed.WithCurrentTimestamp();
            Embed.AddInlineField("User input:", Input1);

            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }
        //*----------------------------------------------------------------------------------------------------*\\

  //      [Command("ocr"), Alias("OCR", "TTI", "tti"), Summary("I/O Image to Text")]
    //    public async Task Imgfixer()
    //
     //   {
      //      AutoOcr OCR = new AutoOcr() { ReadBarCodes = false };
      //      var Results = OCR.Read(@"c:\botDL\image.png");
      //      await Context.Channel.SendMessageAsync(Results.Text + "");
     //   }
     //
        //*----------------------------------------------------------------------------------------------------*\\
    }
}
