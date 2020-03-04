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
    public partial class scoutView : ContentPage
    {
        ScoutedInfo inf;
        public scoutView(ScoutedInfo info)
        {
            InitializeComponent();
            inf = info;
        }

        protected override void OnAppearing()
        {
            eventListView.updateList(inf.eventList);
            eventParametersView.updateParas(inf);
            isOpening = false;
            base.OnAppearing();
        }

        bool isViewingEvents = true;

        private void switchView_Clicked(object sender, EventArgs e)
        {
            if (isViewingEvents)
            {
                switchView.Text = DataConstants.events;
            }
            else
            {
                switchView.Text = DataConstants.parameter;
            }
            isViewingEvents = !isViewingEvents;
            eventListView.IsVisible = isViewingEvents;
            eventParametersView.IsVisible = !isViewingEvents;
        }

        private void finishBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        bool isOpening = false;
        private void EditClicked(object sender, EventArgs e)
        {
            if (!isOpening)
            {
                isOpening = true;
                scoutEvents pg = new scoutEvents(inf, !isViewingEvents);
                pg.Title = this.Title;
                Navigation.PushAsync(pg, false);
            }
        }
    }
}