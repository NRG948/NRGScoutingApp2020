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
        public static void getTeamsNames()
        {
            try
            {
                string response;
                do
                {
                    RestRequest request = new RestRequest("/teams");
                    request.AddJsonBody("{\"year\":2020}");
                    response = client.Post(request).Content;
                } while (String.IsNullOrEmpty(response));

                // array of response
                populateTeamList(response, App.teamsList);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Update the list of competition names, mainly for AddCompetition page, pulling from Shrey's server
        /// </summary>
        public static void getEventsNames()
        {

            try
            {
                string response;
                do
                {
                    RestRequest request = new RestRequest("/events");
                    request.AddJsonBody("{\"year\":2020}");
                    response = client.Post(request).Content;
                } while (String.IsNullOrEmpty(response));

                
                JArray a = JArray.Parse(response);

                foreach (JObject s in a)
                {
                    string key = (string) s["key"];
                    string value = (string) s["name"];
                    App.eventsKeyName.Add(key, value);
                }
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
                do
                {
                    RestRequest request = new RestRequest("/event/matches");
                    request.AddJsonBody("{\"event_key\": \"" + eventKey + "\",\"comp_level\": \"qm\",\"uses_sets\": false}");
                    response = client.Post(request).Content;
                } while (String.IsNullOrEmpty(response));

                CompetitionClass competition = new CompetitionClass();
                JObject a = JObject.Parse(response);

                foreach (KeyValuePair<string, JToken> s in a)
                {
                    Match aMatch = new Match();
                    aMatch.number = int.Parse(s.Key);
                    BlueRedJObject allianceInfo = JsonConvert.DeserializeObject<BlueRedJObject>(s.Value.ToString());
                    int[] blue = allianceInfo.blueTeams.ToArray();
                    int[] red = allianceInfo.redTeams.ToArray();
                    aMatch.setAlliance(true, blue);
                    aMatch.setAlliance(false, red);
                    competition.matchesList.Add(aMatch);
                }
                return competition;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
            return null;
        }

        private class BlueRedJObject
        {
            public List<int> blueTeams { get; set; }
            public List<int> redTeams { get; set; }
        }
    }
}
