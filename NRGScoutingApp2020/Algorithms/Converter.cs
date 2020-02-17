using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Algorithms
{
    public static class Converter
    {
        /*
         * Convert a matchevent object to a JSON object
         * 
         * pre: a MatchEventClass object
         * post: a JSON string
         */
        public static string eventToJSON()
        {
            return "";
        }
        
        /*
         * Convert a string of JSON object to a matchevent object
         * 
         * pre: a JSON string 
         * post: a MatchEventClass object
         */

        public static MatchEventClass JSONToEvent()
        {
            return new MatchEventClass();
        }

        /*
         * Convert a match object to a JSON object
         * 
         * pre: a Match object
         * post: a JSON string
         */
        public static string matchToJSON()
        {
            return "";
        }

        /*
         * Convert a string of JSON object to a match object
         * 
         * pre: a JSON string 
         * post: a Match object
         */

        public static Match JSONToMatch()
        {
            return new Match();
        }

    }
}
