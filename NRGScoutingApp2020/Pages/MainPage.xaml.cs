using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static NRGScoutingApp2020.App;

namespace NRGScoutingApp2020
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            matchEvents.ItemsSource = eventsListObj;

        }

        async private void matchEvents_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MatchEventClass matchEventItem = e.Item as MatchEventClass;
            openMatch(matchEventItem);
        }

        async private void openMatch(MatchEventClass competition)
        {

        }

        async private void newMatch(object sender, System.EventArgs e)
        {
            string name = await DisplayPromptAsync("Enter the name", "What is the name of the competition?");
            name = name.Trim();
            for (int i = 0; i < eventsListObj.Count(); i++)
            {
                if (eventsListObj.ElementAt(i).name == name)
                {
                    bool openOld = await DisplayAlert("Error: Name Repeated", "There is a competition with the same name," +
                        " would you like to open that instead?", "Yes", "Cancel");
                    if (openOld)
                    {
                        openMatch(eventsListObj.ElementAt(i)); // open old competition
                    } 
                    return;
                }
            }
            MatchEventClass newEvent = new MatchEventClass();
            newEvent.name = name;
            eventsListObj.Add(newEvent);
            openMatch(newEvent);
            // create new competition
        
        }
    }
}
