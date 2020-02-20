using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public MatchList(CompetitionClass competition)
        {
            Competition = competition;
            InitializeComponent();
            Title = competition.name;
            Matches.ItemsSource = competition.matchesList.Where(match => match.isFilled);
            lastMatch = -1;
            lastSelect = -1;
        }

        async private void NewMatch(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewMatch(Competition)).ConfigureAwait(false);
        }

        private void Matches_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}