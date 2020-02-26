using NRGScoutingApp2020.Pages;
using NRGScoutingApp2020.Pages.DataManagement;
using NRGScoutingApp2020.Pages.MatchEventSubpage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static NRGScoutingApp2020.App;

namespace NRGScoutingApp2020
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        bool isOpening = false;
        public MainPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            isOpening = false;
            base.OnAppearing();

            matchEvents.ItemsSource = eventsListObj;
        }

        private void matchEvents_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!isOpening)
            {
                isOpening = true;
                CompetitionClass matchEventItem = e.Item as CompetitionClass;
                openMatch(matchEventItem);
            }
        }

        private void openMatch(CompetitionClass competition)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                // Code to run on the main threat
                await Navigation.PushAsync(new MatchList(competition)).ConfigureAwait(false);
            });
        }

        async private void newMatch(object sender, System.EventArgs e)
        {
            matchEvents.ItemsSource = eventsListObj; 
            await Navigation.PushAsync(new AddCompetition()).ConfigureAwait(false);
        }

        private void Debuggerr_Clicked(object sender, EventArgs e)
        {
            foreach (CompetitionClass comp in eventsListObj)
            {
                Console.WriteLine(comp.name);

            }
            Preferences.Clear();

        }

        async private void manageData(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DataManage()).ConfigureAwait(false);
        }
    }
}
