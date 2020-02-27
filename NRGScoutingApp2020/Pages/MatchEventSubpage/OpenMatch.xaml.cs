using NRGScoutingApp2020.Data;
using NRGScoutingApp2020.Pages.MatchEventSubpage.MatchSubpage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static NRGScoutingApp2020.App;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpenMatch : ContentPage
    {
        Match thisMatch;
        List<Button> buttons = new List<Button>();
        int selectID = -1;
        public OpenMatch(Match m)
        {
            InitializeComponent();
            thisMatch = m;


            for (int i = 0; i < 6; i++)
            {
                Button btn = new Button
                {
                    BackgroundColor = Color.Gold,
                    TextColor = Color.White,
                    BorderColor = Color.Orange,
                    BorderWidth = 2,
                    Text = thisMatch.TeamsScouted[i] == null ? DataConstants.canCreate : DataConstants.canEdit,
                    StyleId = i + ""
                };
                btn.Clicked += DynamicClickedEvent;
                buttons.Add(btn);
                if (i < 3)
                {
                    PrematchGrid.Children.Add(btn, 1, i + 1);
                }
                else
                {
                    PrematchGrid.Children.Add(btn, 2, i - 2);
                }
            }
        }

        private void DynamicClickedEvent(object sender, EventArgs e)
        {
            if (selectID >= 0)
            {
                buttons[selectID].IsEnabled = true;
            }

            Button btn = sender as Button;
            selectID = int.Parse(btn.StyleId);
            btn.IsEnabled = false;

            showTeamInfo();

            openInfo.IsEnabled = true;
            openInfo.Text = btn.Text;
        }

        /// <summary>
        /// shows the team number and the team name
        /// </summary>
        private void showTeamInfo()
        {
            int tm = selectID >= 3 ? thisMatch.getTeamAtPos(false, selectID - 2)
                : thisMatch.getTeamAtPos(true, selectID + 1);

            teamNum.Text = tm + "";
            teamNick.Text = teamsList[tm];
        }

        bool isOpening = false;

        protected override void OnAppearing()
        {
            isOpening = false;
            base.OnAppearing();
        }

        private void openInfo_Clicked(object sender, EventArgs e)
        {
            if (!isOpening)
            {
                isOpening = true;
                scoutEvents pg;
                if (thisMatch.TeamsScouted[selectID] == null)
                {
                    pg = new scoutEvents(thisMatch, selectID);
                }
                else
                {
                    pg = new scoutEvents(thisMatch.TeamsScouted[selectID]);
                }
                pg.Title = DataConstants.alliancePosition[selectID];
                Navigation.PushAsync(pg);
                Navigation.RemovePage(this);
            }
        }
    }
}