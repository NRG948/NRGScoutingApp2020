using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Xamarin.Essentials;

namespace NRGScoutingApp2020.Algorithms
{
    public static class LoadData
    {
        /// <summary> 
        /// This method returns the competition objects from cache 
        /// </summary>
        public static ObservableCollection<CompetitionClass> LoadEvents()
        {
            if (Preferences.ContainsKey("compKeys"))
            {
                List<string> keys = JsonConvert.DeserializeObject<List<string>>(Preferences.Get("compKeys", "{}"));

                ObservableCollection<CompetitionClass> competitions = new ObservableCollection<CompetitionClass>();

                foreach (string key in keys)
                {
                    CompetitionClass comp = LoadEvent(key);
                    if (comp != null)
                    {
                        competitions.Add(comp);
                    }
                }
                return competitions;
            }
            return new ObservableCollection<CompetitionClass>();
        }

        /// <summary>
        /// returns one competition object in cache from an event key
        /// </summary>
        /// <param name="compKey"></param>
        /// <returns></returns>
        public static CompetitionClass LoadEvent(string compKey)
        {
            if (Preferences.ContainsKey(compKey))
            {
                return JsonConvert.DeserializeObject<CompetitionClass>(Preferences.Get(compKey, "{}"));
            }
            return null;
        }

        /// <summary>
        /// return the keys and names of the competitions in cache
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> LoadEventsList()
        {
            if (Preferences.ContainsKey("events"))
            {
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(Preferences.Get("events", "{}"));
            }
            return new Dictionary<string, string>();
        }

        /// <summary>
        /// return the numbers and the nicknames of the competitions in cache
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> LoadTeamsList()
        {
            if (Preferences.ContainsKey("teams"))
            {
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(Preferences.Get("teams", "{}"));
            }
            return new Dictionary<string, string>();

        }
    }
}
