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
using NRGScoutingApp2020.Data;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewMatch : ContentPage
    {
        CompetitionClass comp;
        List<Button> buttons = new List<Button>();
        int selectID = -1;
        int matchNumber = 0;
        public AddNewMatch(CompetitionClass competition)
        {
            InitializeComponent();

            if (competition.matchesList.Count == 0) 
            {
                throw new MissingMemberException();
            }

            comp = competition;

            for (int i = 0; i < 6; i++)
            {
                Button btn = new Button
                {
                    BackgroundColor = Color.Gold,
                    TextColor = Color.White,
                    BorderColor = Color.Orange,
                    BorderWidth = 2,
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

            if (lastMatch >= 1 && lastMatch <= comp.matchesList.Count && lastSelect >= 0)
            {
                @continue.IsVisible = true;
            }
        }

        /// <summary>
        /// custom click event for the buttons in the alliance selection view,
        /// select a position to scout and enable the creation of new event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DynamicClickedEvent(object sender, EventArgs e)
        {
            if (selectID >= 0)
            {
                buttons[selectID].IsEnabled = true;
                buttons[selectID].Text = DataConstants.canSelect;
            }

            Button btn = sender as Button;
            selectID = int.Parse(btn.StyleId);
            btn.IsEnabled = false;
            btn.Text = DataConstants.selecting;

            showTeamInfo();

            CreateNew.IsEnabled = true;
        }

        /// <summary>
        /// shows the team number and the team name
        /// </summary>
        private void showTeamInfo()
        {
            int tm = selectID >= 3 ? comp.matchesList[matchNumber].getTeamAtPos(false, selectID - 2)
                : comp.matchesList[matchNumber].getTeamAtPos(true, selectID + 1);

            teamNum.Text = tm + "";
            teamNick.Text = teamsList[tm];
        }

        /// <summary>
        /// calls updateView with new text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matchNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateView(e.NewTextValue);
        }

        /// <summary>
        /// validate the new match number and set the alliance selection view
        /// </summary>
        /// <param name="newNum"></param>
        private void updateView(string newNum)
        {
            Prematching.IsVisible = false;
            CreateNew.IsEnabled = false;
            invalidText.IsVisible = true;
            if (!String.IsNullOrWhiteSpace(newNum) && !String.IsNullOrEmpty(newNum))
            {
                try
                {
                    matchNumber = int.Parse(newNum);
                    if (matchNumber > 0 && matchNumber <= comp.matchesList.Count)
                    {
                        selectID = -1;
                        int count = 0;
                        for (int i = 0; i < 6; i++)
                        {
                            ScoutedInfo inf = comp.matchesList[matchNumber].TeamsScouted[i];
                            buttons[i].IsEnabled = inf == null ? true : false;
                            buttons[i].Text = inf == null ? DataConstants.canSelect : DataConstants.scouted;
                            count += inf == null ? 0 : 1;
                        }
                        if (count == 6)
                        {
                            invalidText.Text = "This match is fully scouted, try another one!";
                        }
                        else
                        {
                            Prematching.IsVisible = true;
                            invalidText.IsVisible = false;
                        }
                    }
                    else
                    {
                        invalidText.Text = "This is not a valid input!";
                    }
                }
                catch (FormatException)
                {
                    invalidText.Text = "Hold on a second... What did you entered??!";
                }
            }
            else
            {
                invalidText.Text = ":)";
            }
        }


        bool isOpening = false;

        private void CreateNew_Clicked(object sender, EventArgs e)
        {
            if (!isOpening)
            {
                isOpening = true;
                lastSelect = selectID;
                lastMatch = matchNumber + 1;
                scoutEvents pg = new scoutEvents(comp.matchesList[matchNumber], selectID);
                pg.Title = DataConstants.alliancePosition[selectID];
                Navigation.PushAsync(pg);
                Navigation.RemovePage(this);
            }
        }

        private void continue_Clicked(object sender, EventArgs e)
        {
            matchNum.Text = lastMatch + "";
            updateView(lastMatch + "");
            selectID = lastSelect;
            showTeamInfo();
            @continue.IsVisible = false;
        }
    }
}