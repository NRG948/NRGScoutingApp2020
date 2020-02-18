using NRGScoutingApp2020.Algorithms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NRGScoutingApp2020
{
    public partial class App : Application
    {
        public static Dictionary<int, String> teamsList = new Dictionary<int, String>();
        public static ObservableCollection<CompetitionClass> eventsListObj = new ObservableCollection<CompetitionClass>();
        public static Dictionary<string, string> eventsKeyName = new Dictionary<string, string>();
        public static Dictionary<int, string> teamsNumName = new Dictionary<int, string>();
        // public static Dictionary<string, int> teamsNameNum = new Dictionary<string, int>();

        public App()
        {
            InitializeComponent();
            DownloadData.startUp();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
