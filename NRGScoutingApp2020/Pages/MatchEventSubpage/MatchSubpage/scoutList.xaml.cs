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
    public partial class scoutList : ContentView
    {
        public scoutList()
        {
            InitializeComponent();
        }
        public void updateList(List<EventItem> items)
        {
            eventList.ItemsSource = items;
        }
    }
}