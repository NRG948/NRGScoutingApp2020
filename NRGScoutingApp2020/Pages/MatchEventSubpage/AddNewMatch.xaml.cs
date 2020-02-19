using NRGScoutingApp2020.Pages.MatchEventSubpage.MatchSubpage;
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
    public partial class AddNewMatch : ContentPage
    {
        CompetitionClass comp;
        public AddNewMatch(CompetitionClass competition)
        {
            InitializeComponent();

            if (competition.matchesList.Count == 0)
            {
                throw new MissingMemberException();
            }

            comp = competition;
        }

        /// <summary>
        /// if the text of the searchbar is changed and is valid,
        /// enable the alliance selection view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matchNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue) || String.IsNullOrEmpty(e.NewTextValue))
            {
                Prematching.IsEnabled = false;
                CreateNew.IsEnabled = false;
            }
            else
            {
                int num = int.Parse(e.NewTextValue);
                if (num > 0 && num <= comp.matchesList.Count)
                {
                    Prematching.matchHere = comp.matchesList[num - 1];
                    Prematching.updateCreate();
                    Prematching.IsEnabled = true;
                    CreateNew.IsEnabled = true;
                } else
                {
                    Prematching.IsEnabled = false;
                    CreateNew.IsEnabled = false;
                }
            }
        }

        private void CreateNew_Clicked(object sender, EventArgs e)
        {

        }
    }
}