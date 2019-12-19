using System;
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
        }

        async void refreshClicked(object sender, System.EventArgs e)
        {
            String key = Environment.GetEnvironmentVariable(Storages.DataConstants.SCOUTING_API_NAME);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Storages.DataConstants.SCOUTING_API_SITE + "/teams");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers["API-Key"] = key;
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
                Console.WriteLine(responseText);
            }
        }
    }
}
