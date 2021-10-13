using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Discord Dependency via Discord.Net 
using Discord.WebSocket;

using System.Text.RegularExpressions;

namespace MetaBot
{
    class SimplifyMessage
    {
        public static void SetupSentence(SocketMessage Message)
        {
            // Get the channel ID, just in case.
            Sentence.channelID = Message.Channel;

            // Get the user's Discord name, to use in example commands.
            Sentence.authorsDiscordName = Message.Author.Username;

            // Just in case we need the exact words used.
            Sentence.original = Message.Content;

            // Make everything lowercase.
            Sentence.simplified = Sentence.original.ToLower();

            // Remove all punctuation.
            Sentence.simplified = Regex.Replace(Sentence.simplified, @"[^\w\s]", "");

            // Check if the message starts with !, indicating it's probably a command.
            // We will still check any other words later.
            if (Sentence.original.StartsWith("!"))
            {
                Sentence.isACommand = true;
            }
            else
            {
                Sentence.isACommand = false;
            }


        }

        public static void DoSynonymReplacement()
        {
            // This could be done via a database.
            // First word is what all the others will be changed into.

            // Materials
            Replace("gold", "golden");
            Replace("red iron", "blood iron", "blood steel");
            Replace("mythril", "mithril");
            Replace("palladium", "carsi");
            Replace("electrum", "white gold");
            Replace("viridium", "orchi");
            Replace("valyan", "evinon steel");
            Replace("ingot", "ingots");
            Replace("ore", "ores");

            // Adjectives
            Replace("fast", "faster");



            // Verbs
            Replace("do", "does", "did");
            Replace("have", "has", "had");
            Replace("who beverb", "whos");
            Replace("problem", "issue", "issues", "problems");
            Replace("who beverb", "who was", "who is", "whos", "who are");
            Replace("what beverb", "whats", "whatre");
            Replace("where beverb", "wheres");
            Replace("did not", "didnt");
            //Replace("do not", "dont");
            Replace("should not", "shouldnt");
            Replace("going to", "gonna", "gunna");
            Replace("beverb not", "isnt", "arent", "wasnt", "werent");
            Replace("beverb", "is", "am", "are", "was", "were", "be");
            Replace("reportingverb", "say", "see", "mention", "declare", "regale", "talking", "whining", "search", "browse", "reminding", "reminding", "speak");
            Replace("it beverb", "its");
            Replace("repair", "repairs", "repaired", "repairing");
            Replace("give", "gives");
            Replace("spawn", "spawning");
            Replace("send", "sent");
            Replace("connect", "connected");
            Replace("crash", "crashed", "crashing");
            Replace("want to", "wanna");
            Replace("make", "making", "makes");
            Replace("create", "creating", "creates");
            Replace("set up", "setting", "sets up");



            // Food
            Replace("apple", "apples");
            Replace("blueberry", "blueberries", "blueberrys", "berry", "berrys", "berries");
            Replace("tomato", "tomatoes", "tomatos");
            Replace("garlic", "garlics");
            Replace("potato", "potatoes", "potatos");
            Replace("eggplant", "eggplants");
            Replace("meat", "meats", "drumstick", "drumsticks");
            Replace("onion", "onions");
            Replace("food", "foods");
            Replace("pumpkin", "pumpkins");
            Replace("potion", "potions");
            Replace("carrot", "carrots");
            Replace("mushroom", "mushrooms", "shroom", "shrooms");
            Replace("egg", "eggs");
            Replace("stew", "soup");


            // Other nouns
            Replace("tradepost", "trade post");
            Replace("atm", "atms");
            Replace("recipe", "recipes");
            Replace("blacksmith mould", "blacksmith recipe");
            Replace("bridge", "bridges");
            Replace("stair", "stairs");

            Replace("skill", "skills");
            Replace("health", "hp");
            Replace("profession", "professions", "job", "jobs");
            Replace("a", "an");
            Replace("character", "characters");

            Replace("bag", "bags", "backpack", "backpacks");
            Replace("mould", "moulds", "mold", "molds");


            Replace("screenshot", "screenshots");
            Replace("image", "images");
            Replace("picture", "pictures");
            Replace("schmeechee", "schmeechees");

            Replace("player", "players", "person", "people", "ppl", "user", "users", "member", "members", "someone", "somebody", "someones", "anyone", "anyones", "anybody", "anybodys", "anybodies", "myself", "yourself");
            Replace("account", "accounts");
            Replace("message", "messages");
            Replace("armour", "armor", "armors", "armours");
            Replace("buckle", "buckles", "buckels", "buckel");
            Replace("televator", "televators", "elevator", "elevators");
            Replace("xp gain", "so gain");
            Replace("xp", "exp", "experience");
            Replace("command", "commands");
            Replace("server", "servers");
            Replace("book", "books");
            Replace("page", "pages");
            Replace("prefab", "prefabs");
            Replace("item", "items");
            Replace("mod", "mods");
            Replace("command", "commands", "commanded");


            // Fillers
            Replace("", "so", "hey", "yo", "ok", "also", "welp", "btw", "yea", "yeah", "guys", "quick question", "pls", "thingie", "atleast", "at least", "heh", "hi", "hello");

            // Typos
            Replace("me", "ne");
            Replace("which", "wich");
            Replace("connected", "conneted");
            Replace("administration", "administartion");
            Replace("you", "u");
            Replace("what", "hat");
            Replace("iron", "iorn");
            Replace("valyan", "val");
            Replace("dosent", "doesnt");
            Replace("myself", "my self");
            Replace("stinger", "stringer");

            Replace("ingame", "in game");






        }




        // Replace vocabulary with more common synonyms. Checks whole sentence at once.
        public static void Replace(string WordToChangeTo, params string[] subjects)
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                Sentence.simplified = Regex.Replace(Sentence.simplified, @"\b" + subjects[i] + @"\b", WordToChangeTo);
            }
            return;
        }





        public static void CheckIfQuestion()
        {
            // This is where we will store the estimate.
            // Keep in mind this method is far from accurate.
            // For this reason, the value may only be used in very limited cases to reduce false positives.
            int Chance = 0;

            string[] PossibleStrongQuestionStarters = { "do", "does", "have", "has", "can", "could", "would", "will", "how", "who", "when", "what", "why", "whose", "where" };

            string[] PossibleWeakQuestionStarters = { "if", "beverb", "would" };

            // Popular question starters are more likely to be questions.
            for (int i = 0; i < PossibleStrongQuestionStarters.Length; i++)
            {
                if (Sentence.simplified.StartsWith(PossibleStrongQuestionStarters[i] + " "))
                {
                    Chance += 65;
                }
            }

            // These could also be starts of questions, but less likely.
            for (int i = 0; i < PossibleWeakQuestionStarters.Length; i++)
            {
                if (Sentence.simplified.StartsWith(PossibleWeakQuestionStarters[i]))
                {
                    Chance += 30;
                }
            }

            // Check for a question mark.
            if (Sentence.original.Contains("?"))
            {
                Chance += 75;
            }


            string[] PossibleMidQuestionPhrases = { "how do", "how can", "what beverb", "beverb wondering", "can you", "anyone know", "did they change", "where beverb", "try", "i need", "help", "want to", "need to", "help", "tell", "explain", "teach", "show", "remind", "how to" };
            for (int i = 0; i < PossibleMidQuestionPhrases.Length; i++)
            {
                if (Sentence.simplified.Contains(PossibleMidQuestionPhrases[i]))
                {
                    Chance += 30;
                }
            }







            // Cap at 100.
            if (Chance > 100) { Chance = 100; }

            Sentence.questionChance = Chance;
        }
    }
}
