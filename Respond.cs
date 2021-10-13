using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using System.Reflection;

namespace MetaBot
{
    public class Respond
    {
        // This method will check if a suitable response exists.
        public static void DoTheSearch()
        {

            var types = Assembly.GetEntryAssembly().GetTypes();


            // Cycle through all methods.
            foreach (var myType in types)
            {


                // Find all methods that start with "Response" to look for matches.
                if (myType.IsClass && myType.IsPublic && myType.Name.StartsWith("Response"))
                {


                    // Get all possible attributes.
                    var attrs = myType.GetCustomAttributes();


                    // Will be set to false if what the user wrote doesn't match that method's criteria.
                    bool isThisResponseValid = true;

                    
                    // Cycle through only the attributes the response being checked has.
                    foreach (var attr in attrs)
                    {
                        // Check that all of the required words or phrases exist in the user's message.
                        if (attr is ATR_Has_AllOfThese myATR_Has_AllOfThese)
                        {
                            // If the required words aren't found, stop checking this particular response.
                            if (!CheckFor.AllOfThese(myATR_Has_AllOfThese.myString))
                            {
                                isThisResponseValid = false;
                                break;
                            }
                        }


                        // Check if at least one of these words or phrases is in the response.
                        if (attr is ATR_Has_AtLeastOneOfThese myATR_Has_AtLeastOneOfThese)
                        {
                            // If at least one of the required words or phrases isn't found, stop checking this particular response.
                            if (!CheckFor.AtLeastOneOfThese(myATR_Has_AtLeastOneOfThese.myString))
                            {
                                isThisResponseValid = false;
                                break;
                            }
                        }


                        // Check that none of these words are in the response. Helps reduce false matches.
                        if (attr is ATR_Has_NoneOfThese myATR_Has_NoneOfThese)
                        {
                            // If one of the forbidden words or phrases is found, stop checking this particular response.
                            if (!CheckFor.NoneOfThese(myATR_Has_NoneOfThese.myString))
                            {
                                isThisResponseValid = false;
                                break;
                            }
                        }


                        // Estimate the chance that the user asked a question. At least 30% certainty is default.
                        else if (attr is ATR_QuestionChance myQuestionChanceAttr)
                        {
                            // If the message is below the minimum chance of being a question, stop checking this response.
                            if (!IsInRange(Sentence.questionChance, myQuestionChanceAttr.min, myQuestionChanceAttr.max))
                            {
                                isThisResponseValid = false;
                                break;
                            }
                        }
                    }


                    // If all criteria are met, call the matching response.
                    if (isThisResponseValid)
                    {
                        Type t = Type.GetType(myType.FullName);
                        MethodInfo method = t.GetMethod("AutoRun", BindingFlags.Static | BindingFlags.Public);
                        /////method.Invoke(null, null);
                        Type.GetType(myType.FullName).GetMethod("AutoRun", BindingFlags.Static | BindingFlags.Public).Invoke(null, null);
                    }
                }
            }
        }



        // Used for checking that the question chance is in range.
        // Turns numbers into a bool.
        private static bool IsInRange(float input, float min, float max)
        {
            bool CheckIfValueIsInRange = false;
            if (input >= min && input <= max) CheckIfValueIsInRange = true;
            return CheckIfValueIsInRange;
        }
    }
}
