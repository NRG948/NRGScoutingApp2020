using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NRGScoutingApp2020
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public IList<MatchEventClass> matchEventsList { get; set; }
        public MainPage()
        {
            InitializeComponent();

            matchEventsList = new List<MatchEventClass>();
            matchEventsList.Add(new MatchEventClass
            {
                name = "GirlsGen",
                date = "I forgot",
                color = "NRG_Red"
            });

            BindingContext = this;
        }

        async private void matchEvents_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MatchEventClass matchEventItem = e.Item as MatchEventClass;
            await Navigation.PushAsync(new MatchEvent { 
                Title = matchEventItem.name
            });
        }

        private void newMatch(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TeamsList());
        }
    }
}
