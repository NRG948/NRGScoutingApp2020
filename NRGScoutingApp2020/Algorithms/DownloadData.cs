using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using NRGScoutingApp2020.Data;
using Newtonsoft.Json;
using System.Diagnostics;

namespace NRGScoutingApp2020.Algorithms
{
    public static class DownloadData
    {
        private static RestClient client = new RestClient(DataConstants.SCOUTING_API_SITE);

        /// <summary>
        /// Setup a default headers for the Rest Client for convenience
        /// </summary>
        public static void startUp()
        {
            client.AddDefaultHeader("API-Key", HideAPIKey.APIKey);
            client.AddDefaultHeader("Content-Type", "application/json");
        }

        /// <summary>
        /// populates a given int,String Dictionary with a given teamList Json
        /// </summary>
        /// <param name="json">the json string of teams</param>
        /// <param name="list">list object to populate</param>
        public static void populateTeamList(string json, Dictionary<int, String> list)
        {
            Debug.WriteLine(json);
            Dictionary<int, String> temp = new Dictionary<int, String>(list);
            JArray repsonse = JArray.Parse(json);
            list.Clear();
            foreach (var s in repsonse)
            {
                JObject v = s.ToObject<JObject>();
                list.Add((int)v["team_number"], (String)v["nickname"]);
            }
            if (list.Count <= 500)
            {
                list = temp;
            }
        }

        /// <summary>
        /// Update the list of team names for the app,  pulling from Shrey's server
        /// </summary>
        /// <returns> whether the request succeed or not </returns>
        public static bool getTeamsNames()
        {
            try
            {
                string response;
                int c = 0;
                do
                {
                    RestRequest request = new RestRequest("/teams");
                    request.AddJsonBody("{\"year\":" + DataConstants.APP_YEAR + "}");
                    response = client.Post(request).Content;

                    c++; // I need to hide a reference somewhere you know

                    if (c > 3)
                    {
                        return false;
                    }

                } while (String.IsNullOrEmpty(response));

                // array of response
                populateTeamList(response, App.teamsList);
                return true;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Update the list of competition names, mainly for AddCompetition page, pulling from Shrey's server
        /// </summary>
        /// <returns> whether the request succeed or not </returns>
        public static bool getEventsNames()
        {

            try
            {
                string response;
                int c = 0;
                do
                {
                    RestRequest request = new RestRequest("/events");
                    request.AddJsonBody("{\"year\":" + DataConstants.APP_YEAR + "}");
                    response = client.Post(request).Content;

                    c++; // I need to hide a reference somewhere you know (copy-and-pasted)

                    if (c > 3)
                    {
                        return false;
                    }

                } while (String.IsNullOrEmpty(response));

                
                JArray a = JArray.Parse(response);

                foreach (JObject s in a)
                {
                    string key = (string) s["key"];
                    string value = (string) s["name"];
                    if (App.eventsKeyName.ContainsKey(key))
                    {
                        App.eventsKeyName[key] = value;
                    }
                    else
                    {
                        App.eventsKeyName.Add(key, value);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Return the MatchEventClass object from a given eventKey, pulling from Shrey's server
        /// </summary>
        /// <param name="eventKey"></param>
        /// <returns></returns>
        public static CompetitionClass getEventSpecific (string eventKey)
        {
            try
            {
                string response;
                int c = 0;

                do
                {
                    RestRequest request = new RestRequest("/event/matches");
                    request.AddJsonBody("{\"event_key\": \"" + eventKey + "\",\"comp_level\": \"qm\",\"uses_sets\": false}");
                    response = client.Post(request).Content;

                    c++; // I need to hide a reference somewhere you know (copy-and-pasted)

                    if (c > 3)
                    {
                        return new CompetitionClass();
                    }

                } while (String.IsNullOrEmpty(response));

                CompetitionClass competition = new CompetitionClass();

                competition.eventKey = eventKey;

                JObject a = JObject.Parse(response);

                for (int i = 1; i <= a.Count; i++ )
                {
                    JToken s = a[i + ""];
                    Match aMatch = new Match();
                    aMatch.number = i;
                    string daList = s.ToString();
                    Console.WriteLine(daList);
                    BlueRedJObject allianceInfo = JsonConvert.DeserializeObject<BlueRedJObject>(daList);
                    int[] blues = allianceInfo.blue.ToArray();
                    int[] reds = allianceInfo.red.ToArray();
                    aMatch.setAlliance(true, blues);
                    aMatch.setAlliance(false, reds);
                    competition.matchesList.Add(aMatch);
                }
                return competition;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        private class BlueRedJObject
        {
            public List<int> blue { get; set; }
            public List<int> red { get; set; }

        }
    }
}
