using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;

namespace NRGScoutingApp2020.Data
{
    public class Teams
    {
        public Teams()
        {
            
        }
        // TODO: Add var for lowest team amt
        public static void populateTeamList(String json, Dictionary<int, String> list)
        {
            Dictionary<int, String> temp = new Dictionary<int, String>(list);
            JArray repsonse = JArray.Parse(json);
            list.Clear();
            foreach (JObject s in repsonse)
            {
                list.Add(Convert.ToInt32(s.GetValue("team_number")), (String)s.GetValue("nickname"));
            }
            if(list.Count <= 500)
            {
                list = temp;
            }
        }

            public static void refreshTeams()
        {
            String key = Environment.GetEnvironmentVariable(DataConstants.SCOUTING_API_NAME);
            key = DataConstants.SCOUTING_API_KEY;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(DataConstants.SCOUTING_API_SITE + "/teams");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("API-Key", key);
            JArray repsonse = new JArray();
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    JObject json = new JObject();
                    json.Add("year", DataConstants.APP_YEAR);
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    populateTeamList(responseText, App.teamsList);
                    Preferences.Set(responseText, DataConstants.TEAM_LIST_STORAGE);
                }
            }
            catch (System.Net.WebException ex)
            {
                throw new Exception("Incorrect API Key or server URL. Please contact IT.");
            }
        }
    }
}
