using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using FLUX.commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FLUX.data;
using System.Diagnostics.Tracing;

namespace FLUX
{
    class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextModule Commands { get; private set; }
        public async Task TaskAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("botConfig.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var config = JsonConvert.DeserializeObject<Config>(json);


            Client = new DiscordClient(new DiscordConfiguration
            {
                Token = config.Token,
                TokenType = TokenType.User,
                AutoReconnect = true,
                LogLevel = LogLevel.Info,
                UseInternalLogHandler = true    
            });

            Commands = Client.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = config.Prefix,
                EnableMentionPrefix = false,
                SelfBot = true,
                CaseSensitive = false,
                EnableDefaultHelp = true,
                EnableDms = true
            });
          
            Commands.RegisterCommands<DefaultCommands>();
            Client.Ready += this.ClientReady;
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
        private Task ClientReady(ReadyEventArgs e)
        {
            e.Client.DebugLogger.LogMessage(LogLevel.Info, "FLUX", $"User {e.Client.CurrentUser.Username} logged in.", DateTime.Now);
            return Task.CompletedTask;
        }
    }
}
