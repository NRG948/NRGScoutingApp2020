using NRGScoutingApp2020.Algorithms.RankingsAlgorithms;
using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage.RankerSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamDetail : ContentPage
    {
        TeamPerformance performance;
        bool isOpening = false;
        public TeamDetail(CompetitionClass competition, Dictionary<ScoutedInfo, int> infos, int num)
        {
            InitializeComponent();

            performance = new TeamPerformance(competition, infos, num);

            for (int i = 0; i < 5; i ++)
            {
                Label datalbl = new Label
                {
                    Text = performance.getValue(i) + "",
                    FontSize = 25,
                    TextColor = Color.IndianRed,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    VerticalOptions = LayoutOptions.Center
                };
                dataGrid.Children.Add(datalbl, 1, i);
            }

            attendedList.ItemsSource = performance.GetMatches();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            isOpening = false;
        }

    }
}