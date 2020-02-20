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
    }
}