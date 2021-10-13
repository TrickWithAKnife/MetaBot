using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaBot
{
    [ATR_QuestionChance(min = 30, max = 100)]
    [ATR_Has_AllOfThese(myString = "a|b|baby shark")]
    [ATR_Has_AtLeastOneOfThese(myString = "apple pie|banana|cake")]
    [ATR_Has_NoneOfThese(myString = "poison|rotten tomato")]
    public class Response_TestResponse
    {
        public static void AutoRun()
        {
            Say.It("Match found.");
        }
    }





    //[ATR_QuestionChance(min = 30, max = 100)]
    [ATR_Has_AllOfThese(myString = "embed|test")]
    //[ATR_Has_AtLeastOneOfThese(myString = "apple pie|banana|cake")]
    //[ATR_Has_NoneOfThese(myString = "poison|rotten tomato")]
    public class Response_TestEmbed
    {
        public static void AutoRun()
        {
            EmbedBuilder FeedbackEmbed = new EmbedBuilder();

            FeedbackEmbed.WithTitle("To Give Moderator Permissions");

            FeedbackEmbed.WithDescription("**Step 1**: Install the Alta Launcher from https://townshiptale.com/download (PC & Question).\n\n**Step 2**: Open the Alta Launcher and sign in.\n\n**Step 3**: Select your server on the far right.\n\n**Step 4**: Right-click the person's in-game name and a menu will appear.\n\n**Step 5**: Click \"Make Moderator\".");

            FeedbackEmbed.WithColor(Color.Green);

            FeedbackEmbed.WithFooter(Sentence.authorsDiscordName + ": " + Sentence.original);

            Say.Embed(FeedbackEmbed);
        }
    }

    //////////////////////////////////////////
    


    [ATR_QuestionChance(min = 30, max = 100)]
    [ATR_Has_AllOfThese(myString = "server")]
    [ATR_Has_AtLeastOneOfThese(myString = "make|create|set up")]
    [ATR_Has_NoneOfThese(myString = "dont")]
    public class Response_HowToStartAServer
    {
        public static void AutoRun()
        {
            EmbedBuilder FeedbackEmbed = new EmbedBuilder();
            FeedbackEmbed.WithTitle("To Create A Server");
            FeedbackEmbed.WithDescription("This is just a placeholder.");
            FeedbackEmbed.WithColor(Color.Green);
            FeedbackEmbed.WithFooter(Sentence.authorsDiscordName + ": " + Sentence.original);
            Say.Embed(FeedbackEmbed);
        }
    }


    [ATR_QuestionChance(min = 30, max = 100)]
    [ATR_Has_AllOfThese(myString = "pvp")]
    [ATR_Has_AtLeastOneOfThese(myString = "turn on|turn off|enable|disabled|set")]
    //[ATR_Has_NoneOfThese(myString = "dont")]
    public class Response_HowToEnableOrDisablePvP
    {
        public static void AutoRun()
        {
            EmbedBuilder FeedbackEmbed = new EmbedBuilder();
            FeedbackEmbed.WithTitle("To Enable & Disable PvP");
            FeedbackEmbed.WithDescription("This is just a placeholder.");
            FeedbackEmbed.WithColor(Color.Green);
            FeedbackEmbed.WithFooter(Sentence.authorsDiscordName + ": " + Sentence.original);
            Say.Embed(FeedbackEmbed);
        }
    }








    [ATR_QuestionChance(min = 30, max = 100)]
    [ATR_Has_AllOfThese(myString = "spawn")]
    [ATR_Has_AtLeastOneOfThese(myString = "item|prefab|command|stuff")]
    [ATR_Has_NoneOfThese(myString = "change|custom")]
    public class Response_HowToSpawnItems
    {
        public static void AutoRun()
        {
            EmbedBuilder FeedbackEmbed = new EmbedBuilder();
            FeedbackEmbed.WithTitle("To Spawn Items");
            FeedbackEmbed.WithDescription("This is just a placeholder.");
            FeedbackEmbed.WithColor(Color.Green);
            FeedbackEmbed.WithFooter(Sentence.authorsDiscordName + ": " + Sentence.original);
            Say.Embed(FeedbackEmbed);
        }
    }




    [ATR_QuestionChance(min = 30, max = 100)]
    [ATR_Has_AllOfThese(myString = "reset")]
    [ATR_Has_AtLeastOneOfThese(myString = "player|character")]
    //[ATR_Has_NoneOfThese(myString = "change|custom")]
    public class Response_HowToResetPlayer
    {
        public static void AutoRun()
        {
            EmbedBuilder FeedbackEmbed = new EmbedBuilder();
            FeedbackEmbed.WithTitle("To Reset A Player");
            FeedbackEmbed.WithDescription("This is just a placeholder.");
            FeedbackEmbed.WithColor(Color.Green);
            FeedbackEmbed.WithFooter(Sentence.authorsDiscordName + ": " + Sentence.original);
            Say.Embed(FeedbackEmbed);
        }
    }















    // Yo does anybody know how to reset a player



}
