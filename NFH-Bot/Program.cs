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
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
//*-------------------------*\\


namespace NFH_Bot
{
    class Program
    {
        private DiscordSocketClient Client;
        private CommandService Commands;

        static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });

            Commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            Client.MessageReceived += Client_MessageRecieved;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());

            Client.Ready += Client_Ready;
            Client.Log += Client_Log;


            // Token reading function- this token will be the one the bot gets from discordapp.com
            string Token = "";
            using (var Stream = new FileStream((Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).Replace(@"bin\Debug\netcoreapp2.1", @"Data\Token.txt"), FileMode.Open, FileAccess.Read))
            using (var ReadToken = new StreamReader(Stream))
            {
                Token = ReadToken.ReadToEnd();
            }

            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();

            await Task.Delay(-1);
        }

        // Simple logging of what happens, when it does, and what the message is.
    private async Task Client_Log(LogMessage Message)
        {
            Console.WriteLine($"{DateTime.Now} at {Message.Source}] {Message.Message}");
        }

    private async Task Client_Ready()
        {
            await Client.SetGameAsync("ex.exe", "https://twitter.com/encore45158090", StreamType.NotStreaming);
        }

        // Task that fires incase you recieve a message- decide prefix here along with pasting the logging incase someone fucks up a command.
        // Which will helpfully paste a cute red text in the console!
    private async Task Client_MessageRecieved(SocketMessage MessageParam)
        {
            var Message = MessageParam as SocketUserMessage;
            var Context = new SocketCommandContext(Client, Message);

            if (Context.Message == null || Context.Message.Content == "") return;
            if (Context.User.IsBot) return;

            int ArgPos = 0;
            if (!(Message.HasStringPrefix("&", ref ArgPos) || Message.HasMentionPrefix(Client.CurrentUser, ref ArgPos))) return;

            var Result = await Commands.ExecuteAsync(Context, ArgPos);
            if (!Result.IsSuccess)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong with executing a command. Text: {Context.Message.Content} | Error {Result.ErrorReason}");
                Console.ResetColor();
        }
    }

}
