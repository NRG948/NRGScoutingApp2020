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
        public AddNewMatch()
        {
            InitializeComponent();
        }

        private void matchNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue) || String.IsNullOrEmpty(e.NewTextValue))
            {
                Prematching.IsEnabled = false;
                CreateNew.IsEnabled = false;
            }
            else
            {
                
            }
        }

        private void CreateNew_Clicked(object sender, EventArgs e)
        {

        }
    }
}