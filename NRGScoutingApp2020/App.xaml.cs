using NRGScoutingApp2020.Algorithms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NRGScoutingApp2020
{
    public partial class App : Application
    {
        public static Dictionary<int, String> teamsList { get; set; } = new Dictionary<int, String>();
        public static ObservableCollection<CompetitionClass> eventsListObj { get ; set ; } = new ObservableCollection<CompetitionClass> ();

        public static Dictionary<string, string> eventsKeyName { get; set; } = new Dictionary<string, string>();
        public static Dictionary<int, string> teamsNumName { get; set; } = new Dictionary<int, string>();
        // public static Dictionary<string, int> teamsNameNum = new Dictionary<string, int>();

        public App()
        {
            InitializeComponent();
            DownloadData.startUp();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Load all data
            teamsNumName = LoadData.LoadTeamsList();
            eventsKeyName = LoadData.LoadEventsList();
            eventsListObj = LoadData.LoadEvents();
        }

        protected override void OnSleep()
        {
            // Cache all data
            CacheData.CacheEvents(eventsListObj);
            CacheData.CacheEventsList(eventsKeyName);
            CacheData.CacheTeamsList(teamsNumName);
        }

        protected override void OnResume()
        {
        }
    }
}
