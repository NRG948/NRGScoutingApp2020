using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Algorithms
{
    public class Converter
    {
        /*
         * Convert a matchevent object to a JSON object
         * 
         * pre: a MatchEventClass object
         * post: a JSON string
         */
        public string eventToJSON()
        {
            return "";
        }
        
        /*
         * Convert a string of JSON object to a matchevent object
         * 
         * pre: a JSON string 
         * post: a MatchEventClass object
         */

        public MatchEventClass JSONToEvent()
        {
            return new MatchEventClass();
        }

        /*
         * Convert a match object to a JSON object
         * 
         * pre: a Match object
         * post: a JSON string
         */
        public string matchToJSON()
        {
            return "";
        }

        /*
         * Convert a string of JSON object to a match object
         * 
         * pre: a JSON string 
         * post: a Match object
         */

        public Match JSONToMatch()
        {
            return new Match();
        }

    }
}
