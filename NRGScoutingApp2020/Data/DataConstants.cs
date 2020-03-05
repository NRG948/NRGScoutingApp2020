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
        public static readonly string main = "main";
        public static readonly string parameter = "parameters";
        public static readonly string events = "events";

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

        public static readonly string[] rankPickerText = { "Accuracy" , "Lower", "Outer", "Inner", "Climb" };

        public static readonly string[] actionTypeList = { "Pick", "Lower", "Outer", "Inner", "Miss"};

        public static readonly int[] typeToBallChanged = { 1, -1, -1, -1, -1 };

        public static readonly string[] climbOptions = { "No Climb", "Park", "Climb", "Climb and Level" };

        public static readonly string[] penaltyOptions = { "No Card", "Yellow Card", "Red Card" };

        public static readonly string[] QUESTIONS = {
            "What drive base do you use?",
            "How much does your robot weigh?",
            "Drive practice hours? (estimate)",
            "Can you climb? if so where on the bar and at what level can you climb?",
            "Low goal or high goal?",
            "Inner port capability?",
            "Trench run capability?",
            "How many power cells per match? (estimate)",
            "What does auto do?",
            "Anything else you would like to tell us?",
            "Other?"
        };

    }
}
