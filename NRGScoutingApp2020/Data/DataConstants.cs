using System;
using System.Collections.Generic;

namespace NRGScoutingApp2020
{
    /// <summary>
    /// Stores all the constants used in the app to allow easy modification
    /// </summary>
    /// 
    public static class DataConstants
    {
        public static readonly string SCOUTING_API_NAME = "NRG_API_KEY";
        public static readonly string SCOUTING_API_KEY = "";
        public static readonly string SCOUTING_API_SITE = "http://api.nrg948.com";
        //https://nrg-scouting-api.herokuapp.com
        public static readonly int APP_YEAR = 2020;
        public static readonly String TEAM_LIST_STORAGE = "TeamsList";


        // Button texts
        public static readonly string canSelect = "select";
        public static readonly string selecting = "selecting";
        public static readonly string canView = "view";
        public static readonly string canCreate = "create";
        public static readonly string scouted = "scouted";

        // Prompt Strings
        public static readonly string EmptyCompetition = "You can not add a competition until the day before it happens!";


        /* Event Types
         * 0: pick
         * 1: lower
         * 2: outer
         * 3: inner
         * 4: miss
         */

        public static readonly string[] alliancePosition = { "Blue 1", "Blue 2", "Blue 3", "Red 1", "Red 2", "Red 3" };

        public static readonly string[] rankPickerText = { "accuracy" , "lower", "outer", "inner", "climb" };

        public static readonly string[] actionTypeList = { "Pick", "Lower", "Outer", "Inner", "Miss"};

        public static readonly int[] typeToBallChanged = { 1, -1, -1, -1, -1 };
    }
}
