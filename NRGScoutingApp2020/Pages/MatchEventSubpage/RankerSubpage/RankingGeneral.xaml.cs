using NRGScoutingApp2020.Algorithms.RankingsAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NRGScoutingApp2020.Data;
using static NRGScoutingApp2020.App;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage.RankerSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RankingGeneral : ContentPage
    {
        CompetitionClass comp;
        Ranker r;
        bool isOpening = false;
        public RankingGeneral(CompetitionClass competition)
        {
            InitializeComponent();
            comp = competition;
            r = new Ranker(comp);

            rankPicker.ItemsSource = DataConstants.rankPickerText;
        }

        private void rankPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            rankList.ItemsSource = r.competitionRank(rankPicker.SelectedIndex);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            isOpening = false;
        }

        private void rankList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!isOpening)
            {
                isOpening = true;
                KeyValuePair<int, double> teamValue = (KeyValuePair<int, double>) e.Item;
                int teamNum = teamValue.Key;
                TeamDetail pg = new TeamDetail(comp, r.getInformations(), teamNum);
                pg.Title = teamsList[teamNum];
                Navigation.PushAsync(pg);
            }
        }
    }
}