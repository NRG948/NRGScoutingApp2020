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
        public scoutParameters()
        {
            InitializeComponent();
        }

        private void IntSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Slider s = sender as Slider;
            s.Value = Math.Round(e.NewValue);
        }
    }
}