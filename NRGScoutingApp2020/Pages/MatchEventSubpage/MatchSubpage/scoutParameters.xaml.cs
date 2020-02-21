using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage.MatchSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class scoutParameters : ContentView
    {
        string[] climbOptions = { "No Climb", "Park", "Climb", "Climb and Level"};
        string[] penaltyOptions = { "No Card", "Yellow Card", "Red Card" };
        public scoutParameters()
        {
            InitializeComponent();
            climbPicker.ItemsSource = climbOptions;
            climbPicker.SelectedIndex = 0;
            penaltyPicker.ItemsSource = penaltyOptions;
            penaltyPicker.SelectedIndex = 0;
        }
        
        /// <summary>
        /// Gives the scouted info object everything entered in this view
        /// </summary>
        /// <param name="fullScout"> the scouted info from the match </param>
        public void setParameters(ScoutedInfo fullScout)
        {
            fullScout.AutoInitiation    = CheckAutoInitiation.IsChecked;
            fullScout.climbPick         = climbPicker.SelectedIndex;
            fullScout.controlPositional = CheckConPositional.IsChecked;
            fullScout.controlRotational = CheckConRotational.IsChecked;
            fullScout.deathRange        = SlideDeath.Value;
            fullScout.penaltyPick       = penaltyPicker.SelectedIndex;
            fullScout.commentt          = Commentt.Text;
        }

        /// <summary>
        /// set everything in this view according to the scouted info provided
        /// </summary>
        /// <param name="fullScout"> the scouted info from the match </param>
        public void setLocParameters(ScoutedInfo fullScout)
        {
            CheckAutoInitiation.IsChecked   = fullScout.AutoInitiation;
            climbPicker.SelectedIndex       = fullScout.climbPick;
            CheckConPositional.IsChecked    = fullScout.controlPositional;
            CheckConRotational.IsChecked    = fullScout.controlRotational;
            SlideDeath.Value                = fullScout.deathRange;
            penaltyPicker.SelectedIndex     = fullScout.penaltyPick;
            Commentt.Text                   = fullScout.commentt;
        }
    }
}