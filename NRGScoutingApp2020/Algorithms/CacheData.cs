using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace NRGScoutingApp2020.Algorithms
{
    public static class CacheData
    {
        /// <summary> This method create cache files
        /// for the events in memory to save all of them
        /// </summary>
        /// <param name="eventsListObj"></param>
        public static void CacheEvents(ObservableCollection<CompetitionClass> eventsListObj)
        {
            List<string> compKeys = new List<string>();
            foreach (CompetitionClass competition in eventsListObj)
            {
                Preferences.Set(competition.eventKey, JsonConvert.SerializeObject(competition));
                compKeys.Add(competition.eventKey);
            }
            Preferences.Set("compKeys", JsonConvert.SerializeObject(compKeys));
        }

        /// <summary>
        /// Save teams downloaded from the server to avoid redownloading
        /// </summary>
        /// <param name="JSONTeams"></param>
        public static void CacheTeamsList(Dictionary<int, string> teams)
        {
            Preferences.Set("teams", JsonConvert.SerializeObject(teams));
        }

        /// <summary>
        /// Save 2020 events list downloaded to avoid redownloading
        /// </summary>
        /// <param name="JSONEvents"></param>
        public static void CacheEventsList(Dictionary<string, string> comps)
        {
            Preferences.Set("events", JsonConvert.SerializeObject(comps));
        }
    }
}
