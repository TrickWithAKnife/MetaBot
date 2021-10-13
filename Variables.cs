using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Discord Dependency via Discord.Net 
using Discord.WebSocket;



namespace MetaBot
{
    public struct Guild
    {
        public static DiscordSocketClient client;
        public static ulong GuideThirteenTestingChannel = 860835084370444339; // TEMP
        






    }

    public struct Sentence
    {
        public static string original;
        public static string simplified;
        public static ISocketMessageChannel channelID;
        public static string authorsDiscordName;
        public static float questionChance;
        public static bool isACommand;
    }

    public struct Vocab
    {
        // Also needs names specific materials
        public static string[] materials = { "oak", "birch", "walnut", "ash", "redwood", "darksteelalloy", "aluminium", "brass", "carsialloy", "copper", "evinonsteelalloy", "gold", "iron", "mythril", "orchialloy", "redironalloy", "silver", "tin", "trainingmetalcold", "trainingmetalhot", "whitegoldalloy", "daisleather", "daisredleather", "unknownleather", "wyrmfaceleather", "canvas", "redwoodgoteracorematerial", "rope",
        "valyan"};
    }
}
