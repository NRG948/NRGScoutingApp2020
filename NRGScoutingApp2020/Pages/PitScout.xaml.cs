using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NRGScoutingApp2020.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PitScout : ContentPage
    {
        bool isOpening = false;
        MainPage p;
        public PitScout()
        {
            InitializeComponent();
            p = Parent as MainPage;
        }

        protected override void OnAppearing()
        {
            isOpening = false;
            base.OnAppearing();
            p.IsVisible = true;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            p.IsVisible = false;
        }

        private void addTeam(object sender, EventArgs e)
        {

        }

        private void exportImport(object sender, EventArgs e)
        {

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}