using NRGScoutingApp2020.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NRGScoutingApp2020.App;

namespace NRGScoutingApp2020.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCompetition : ContentPage
    {
        public AddCompetition()
        {
            InitializeComponent();
            if (eventsKeyName.Count == 0)
            {
                DownloadData.getEventsNames();
            }
            competitions.ItemsSource = eventsKeyName.Values;
        }

        private void competitions_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }

        /// <summary>
        /// Update list when the text in search bar is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SEARCH_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(e.NewTextValue) || String.IsNullOrEmpty(e.NewTextValue))
            {
                competitions.ItemsSource = eventsKeyName.Values;
            }
            else
            {
                competitions.ItemsSource = eventsKeyName.Values.Where(value => value.ToLower().Trim().Contains(e.NewTextValue.ToLower().Trim()));
            }
        }
    }
}