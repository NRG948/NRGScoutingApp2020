using NRGScoutingApp2020.Algorithms;
using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NRGScoutingApp2020.App;


namespace NRGScoutingApp2020.Pages.MatchEventSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchList : ContentPage
    {
        CompetitionClass Competition;
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    updateMatches();
                    cacheCompetition();
                    Matches.IsRefreshing = false;
                });
            }
        }

        private void updateMatches()
        {
            Matches.ItemsSource = Competition.matchesList.Where(match => match.isFilled);
        }

        private void cacheCompetition()
        {
            CacheData.CacheOneEvent(Competition);
        }
        public MatchList(CompetitionClass competition)
        {
            InitializeComponent();
            Competition = competition;
            Title = competition.name;
            lastMatch = -1;
            lastSelect = -1;
            Matches.RefreshCommand = RefreshCommand;
        }

        async private void NewMatch(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewMatch(Competition)).ConfigureAwait(false);
        }

        async private void Matches_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Match m = e.Item as Match;

            await Navigation.PushAsync(new OpenMatch(m)).ConfigureAwait(false);
        }
        protected override void OnDisappearing()
        {
            cacheCompetition();
            base.OnDisappearing();
        }
    }
}