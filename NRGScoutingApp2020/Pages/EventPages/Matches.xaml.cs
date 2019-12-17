using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NRGScoutingApp2020.Storages.MatchEventsConstants;

namespace NRGScoutingApp2020.Pages.EventPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Matches : ContentPage
    {
        public Matches()
        {
            InitializeComponent();
            matchView.ItemsSource = matchList;
        }
    }
}