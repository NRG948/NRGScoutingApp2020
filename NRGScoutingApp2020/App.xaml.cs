using NRGScoutingApp2020.Algorithms;
using NRGScoutingApp2020.Pages;
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
        public static List<string> eventsNotLocal = new List<string>();
        // public static Dictionary<string, int> teamsNameNum = new Dictionary<string, int>();
        public static int lastMatch;
        public static int lastSelect;

        public App()
        {
            InitializeComponent();
            DownloadData.startUp();
            MainPage mp = new MainPage();
            MainPage = new NavigationPage(mp)
            {
                BarBackgroundColor = Color.IndianRed,
                BarTextColor = Color.White,
                Title = "2020"
            };
            
        }

        protected override void OnStart()
        {
            // Load all data
            teamsList = LoadData.LoadTeamsList();
            eventsKeyName = LoadData.LoadEventsList();
            eventsListObj = LoadData.LoadEvents();
        }

        protected override void OnSleep()
        {
            // Cache all data
            CacheData.CacheEvents(eventsListObj);
        }

        protected override void OnResume()
        {
        }
    }
}
