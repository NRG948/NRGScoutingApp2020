using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace NRGScoutingApp2020.Pages
{
    public partial class TeamsList : ContentPage
    {
        public TeamsList()
        {
            InitializeComponent();
            TeamList.ItemsSource = App.teamsList;
            TeamList.RefreshCommand = new Command(() =>
            {
                //Do your stuff.
                refreshTeams();
                TeamList.IsRefreshing = false;
            });
        }

        void populateTeamList(String json, Dictionary<int, String> list)
        {
            JArray repsonse = JArray.Parse(json);
            list.Clear();
            foreach (JObject s in repsonse)
            {
                list.Add(Convert.ToInt32(s.GetValue("team_number")), (String)s.GetValue("nickname"));
            }
        }

        void populateTeamList(String json, Dictionary<int, String> list, ListView listView)
        {
            populateTeamList(json, list);
            listView.ItemsSource = null;
            listView.ItemsSource = list;
        }
        async void refreshTeams()
        {

            String key = Environment.GetEnvironmentVariable(Storages.DataConstants.SCOUTING_API_NAME);
            key = Storages.DataConstants.SCOUTING_API_KEY;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Storages.DataConstants.SCOUTING_API_SITE + "/teams");
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
                    json.Add("year", Storages.DataConstants.APP_YEAR);
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    populateTeamList(responseText, App.teamsList, TeamList);
                }
            }
            catch (System.Net.WebException ex)
            {
                await DisplayAlert("Incorrect API Key or server URL", "Contact IT Captain", "OK");
                Console.WriteLine(ex);
            }
        }
    }
}
