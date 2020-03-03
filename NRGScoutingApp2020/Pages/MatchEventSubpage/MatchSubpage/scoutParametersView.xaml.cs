using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage.MatchSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class scoutParametersView : ContentView
    {
        public scoutParametersView()
        {
            InitializeComponent();
        }

        public void updateParas(ScoutedInfo inf)
        {
            initiationText.Text = inf.AutoInitiation + "";
            climbText.Text = DataConstants.climbOptions[inf.climbPick];
            string panelGet = "No interaction";
            if (inf.controlPositional)
            {
                if (inf.controlRotational)
                {
                    panelGet = "Position and Rotation";
                }
                else
                {
                    panelGet = "Position";
                }
            }
            else
            {
                if (inf.controlRotational)
                {
                    panelGet = "Rotation";
                }
            }
            panelText.Text = panelGet;
            defendText.Text = inf.magnitudeDefend + " (max 5)";
            defendedText.Text = inf.magnitudeDefended + " (max 5)";
            deathText.Text = inf.deathRange.ToString("P", CultureInfo.InvariantCulture);
            penaltyText.Text = DataConstants.penaltyOptions[inf.penaltyPick];
            commentt.Text = inf.commentt;
        }
    }
}