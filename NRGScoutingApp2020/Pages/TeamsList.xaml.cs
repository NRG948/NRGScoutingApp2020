using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using NRGScoutingApp2020.Data;
using Xamarin.Essentials;

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
                TeamList.IsRefreshing = true;
                try
                {
                    Teams.refreshTeams();
                }
                catch(Exception ex)
                {
                    DisplayAlert(ex.ToString(),"", "OK");
                }
                populateTeamList(TeamList);
                TeamList.IsRefreshing = false;
            });
        }

        void populateTeamList(ListView listView)
        {
            if(App.teamsList.Count <= 0)
            {
                Teams.populateTeamList(Preferences.Get(DataConstants.TEAM_LIST_STORAGE, "{}"), App.teamsList);
            }
            listView.ItemsSource = null;
            listView.ItemsSource = App.teamsList;
        }
    }
}
