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
            string compKeys = "";
            foreach (CompetitionClass competition in eventsListObj)
            {
                CacheEvent(competition);
                compKeys += competition.eventKey + ";";
            }
            Preferences.Set("compKeys", compKeys);
        }
        
        /// <summary>
        /// Cache only one competition to storage
        /// </summary>
        /// <param name="comp"></param>
        private static void CacheEvent(CompetitionClass comp)
        {
            Preferences.Set(comp.eventKey, JsonConvert.SerializeObject(comp));
        }


        /// <summary>
        /// Stores one eventKey 
        /// </summary>
        /// <param name="comp"></param>
        private static void CacheOneEventKey(CompetitionClass comp)
        {
            if (Preferences.ContainsKey("compKeys"))
            {
                string keys = Preferences.Get("compKeys", "");
                if (!keys.Contains(comp.eventKey))
                {
                    Preferences.Set("compKeys", Preferences.Get("compKeys", "") + comp.eventKey + ";");
                }
            }
            else
            {
                Preferences.Set("compKeys", comp.eventKey + ";");
            }
        }

        /// <summary>
        /// Cache individual competition
        /// </summary>
        /// <param name="comp"></param>
        public static void CacheOneEvent(CompetitionClass comp)
        {
            CacheEvent(comp);
            CacheOneEventKey(comp);
        }

        /// <summary>
        /// Save teams downloaded from the server to avoid redownloading
        /// </summary>
        /// <param name="JSONTeams"></param>
        public static void CacheTeamsList(Dictionary<int, string> teams)
        {
            Preferences.Set("teams", JsonConvert.SerializeObject(teams));
        }

        public static void DeleteOneEvent(CompetitionClass comp)
        {
            string keys = Preferences.Get("compKeys", "");
            if (keys.Contains(comp.eventKey))
            {
                int compKeyInd = keys.IndexOf(comp.eventKey);
                string newKeys = keys.Substring(0, compKeyInd) + keys.Substring(compKeyInd + comp.eventKey.Length + 1);
                Console.WriteLine(keys);
                Console.WriteLine(newKeys);
                Preferences.Set("compKeys", newKeys);
                Preferences.Remove(comp.eventKey);
            }
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
