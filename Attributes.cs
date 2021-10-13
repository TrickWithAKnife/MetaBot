using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaBot
{
    // All of these words or phrases are required.
    // Separated with |.
    public class ATR_Has_AllOfThese : Attribute
    {
        public string myString;
    }


    // At least one of these words or phrases are required.
    // Separated with |.
    public class ATR_Has_AtLeastOneOfThese : Attribute
    {
        public string myString;
    }


    // If any of these words or phrases are found, the response is invalid. 
    // Separated with |.
    public class ATR_Has_NoneOfThese : Attribute
    {
        public string myString;
    }


    // The acceptable chance that a user's message is a question. 
    // The numbers represent percentages, so 0% - 100%.
    // There are few situations where max needs to be lower than 100.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class ATR_QuestionChance : Attribute
    {
        public int min;
        public int max;
    }


}
