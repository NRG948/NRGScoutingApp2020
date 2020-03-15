using NRGScoutingApp2020.Algorithms;
using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NRGScoutingApp2020.App;

namespace NRGScoutingApp2020.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTeamPitScout : ContentPage
    {
        private ICommand getList
        {
            get
            {
                return new Command(() =>
                {
                    if (DownloadData.getTeamsNames())
                    {
                        CacheData.CacheTeamsList(teamsList);
                    }
                    else
                    {
                        DisplayAlert("Connection Error", "Cannot get the list of teams", "Oh no...");
                    }
                    teams.IsRefreshing = false;
                    updateList(SEARCH.Text);
                });
            }

        }
        public AddTeamPitScout()
        {
            InitializeComponent();

            teamsLocal = new List<int>();

            foreach (TeamClass t in teamsListObj)
            {
                teamsLocal.Add(t.)
            }

            updateList();
        }

        private void teams_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void updateList()
        {
            teams.ItemsSource = null;
            List<TextCell> l = new List<TextCell>();
            foreach (KeyValuePair<int, string> pair in teamsList)
            {
                if 
            }
            teams.ItemsSource = teamsList;
        }

        private void updateList(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                updateList();
                return;
            }
            teams.ItemsSource = null;
            teams.ItemsSource = teamsList.Where(pair => pair.Value.Contains());
        }

        private void SEARCH_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateList(e.NewTextValue);
        }
    }
}