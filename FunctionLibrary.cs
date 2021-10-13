using Discord;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaBot
{
    public class Say
    {

        // This is called to send a message on discord.
        // May not be needed.
        public async static void It(string whatToSay) // TESTING ONLY
        {
            Console.WriteLine("Bot will say: " + whatToSay);
            Sentence.channelID.SendMessageAsync(whatToSay);
        }




        // This is called to send an embed to discord.
        public async static void Embed(EmbedBuilder importedEmbedBuilder)
        {
            var responseChannel = Guild.client.GetChannel(Sentence.channelID.Id) as IMessageChannel;
            await responseChannel.SendMessageAsync("", false, importedEmbedBuilder.Build()); // THE REAL ONE
            Console.WriteLine("Should have shown an embed in discord");
        }







    }


    // These methods are all used when checking if a messages fits criteria set by responses.
    public class CheckFor
    {


        // Check if all of the required words exist in the user's message.
        public static bool AllOfThese(string inputString)
        {
            // Split the string into an array at each |, so each word or phrase can be checked separately.
            string[] args = inputString.Split('|');

            // Set the default value. Will be false if a required word or phrase isn't found.
            bool wereAllFound = true;

            // Check the length of the array, and cycle through each item for checking.
            for (int i = 0; i < args.Length; i++)
            {
                // Set the word or phrase to check exists.
                string CurrentArgValue = args[i].ToString();

                // If the word or phrase is found, set the bool to true.
                // If the word or phrase is not found, set the bool to false.
                bool contains = Regex.IsMatch(Sentence.simplified, @"(?<![\w])" + CurrentArgValue + @"(?![\w])");

                // If the word or phrase isn't found, this method is false.
                if (!contains)
                {
                    // This method is false.
                    wereAllFound = false;
                 
                    // Stop checking, because we know this method will return false.
                    break;
                }
            }
            // Return true or false.
            return wereAllFound;
        }



        public static bool AtLeastOneOfThese(string inputString)
        {
            // Split the string into an array at each |, so each word or phrase can be checked separately.
            string[] args = inputString.Split('|');

            // Set the default value. Will be true if a needed word or phrase is found.
            bool wasOneFound = false;

            // Check the length of the array, and cycle through each item for checking.
            for (int i = 0; i < args.Length; i++)
            {
                // Set the word or phrase to check exists.
                string CurrentArgValue = args[i].ToString();

                // If the word or phrase is found, set the bool to true.
                // If the word or phrase is not found, set the bool to false.
                bool contains = Regex.IsMatch(Sentence.simplified, @"(?<![\w])" + CurrentArgValue + @"(?![\w])");

                if (contains)
                {
                    // A suitable word or phrase was found
                    wasOneFound = true;

                    // Stop checking, because we know a suitable word or phrase was found.
                    break;
                }
            }
            // Return true or false.
            return wasOneFound;
        }


        public static bool NoneOfThese(string inputString)
        {
            // Split the string into an array at each |, so each word or phrase can be checked separately.
            string[] args = inputString.Split('|');

            bool wereNoneFound = true;

            for (int i = 0; i < args.Length; i++)
            {
                string CurrentArgValue = args[i].ToString();

                // If the word or phrase is found, set the bool to true.
                // If the word or phrase is not found, set the bool to false.
                bool contains = Regex.IsMatch(Sentence.simplified, @"(?<![\w])" + CurrentArgValue + @"(?![\w])");

                if (contains)
                {
                    wereNoneFound = false;

                    // An unwanted word or phrase was found, so stop checking.
                    break;
                }
            }
            //Console.WriteLine("wasOneFound = " + wereNoneFound);
            return wereNoneFound;
        }










        /*public bool Start(string phraseToCheckFor)
        {
            if (Sentence.simplified.StartsWith(phraseToCheckFor)) return true;
            else return false;
        }*/

       




        // This will be used to check if a !command is valid.
        // Not implimented yet, but will be soon.
        public static bool Command(string commandString)
        {
            // All commands will start with !
            if (Sentence.original.ToLower().Contains("!" + commandString)) return true;
            else return false;
        }
    }
}
