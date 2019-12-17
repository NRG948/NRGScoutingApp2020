using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NRGScoutingApp2020.Pages.EventPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventRanking : ContentPage
    {
        public EventRanking()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            restartable.Text = (Application.Current as App).textbox;

        }

        private void restartable_TextChanged(object sender, TextChangedEventArgs e)
        {
            (Application.Current as App).textbox = restartable.Text;
        }
    }
}