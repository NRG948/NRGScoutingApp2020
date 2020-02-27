using NRGScoutingApp2020.Algorithms.RankingsAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NRGScoutingApp2020.Data;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage.RankerSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RankingGeneral : ContentPage
    {
        CompetitionClass comp;
        Ranker r;
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
    }
}