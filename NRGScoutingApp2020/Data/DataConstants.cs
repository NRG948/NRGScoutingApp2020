using System;
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
        public static readonly int APP_YEAR = 2019;
        public static readonly String TEAM_LIST_STORAGE = "TeamsList";


        // Button texts
        public static readonly string canSelect = "select";
        public static readonly string selecting = "selecting";
        public static readonly string canEdit = "edit";
        public static readonly string canCreate = "create";

        // Prompt Strings
        public static readonly string EmptyCompetition = "You can not add a competition until the day before it happens!";
    }
}
