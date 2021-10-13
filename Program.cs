using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Discord Dependencies via Discord.Net 
using Discord;
using Discord.WebSocket;

namespace MetaBot
{
    class Program
    {
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();


        public async Task MainAsync()
        {
            Console.WriteLine("Logging in...\n");
            Guild.client = new DiscordSocketClient();

            await Guild.client.LoginAsync(TokenType.Bot, "ODc2MTUyNjUwNzYzMjEwNzky.YRf6vg.U0EFrtjry7Ty7ifzKxfZFVbHx4c"); // Don't share this line...
            await Guild.client.StartAsync();

            Console.WriteLine("Connected to Discord.");

            Guild.client.MessageReceived += ProcessMessage;
            await Task.Delay(-1);




        }


        private async Task ProcessMessage(SocketMessage Message)
        {
            // Ignore bots
            if (Message.Author.IsBot) return;

            // Only listen to the approved channel
            if (Message.Channel.Id.ToString() != "876154344339296298") return;

            // Created a simplified version of the user's input as Sentence.simplified.
            SimplifyMessage.SetupSentence(Message);

            // Reduce missed questions due to phrasing not being as expected.
            SimplifyMessage.DoSynonymReplacement();

            // Estimate the chances the user is asking a question to reduce false positives.
            SimplifyMessage.CheckIfQuestion();

            Console.WriteLine("Tidied: " + Sentence.simplified);

            Respond.DoTheSearch();







        }









    }
}
