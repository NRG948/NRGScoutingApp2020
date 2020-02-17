using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchList : ContentPage
    {
        MatchEventClass Competition;
        public MatchList(MatchEventClass competition)
        {
            Competition = competition;
            InitializeComponent();
            Title = competition.name;
            Matches.ItemsSource = competition.matchesList.Where(match => match.isFilled());
        }

        async private void NewMatch(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewMatch()).ConfigureAwait(false);
        }

        private void Matches_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}