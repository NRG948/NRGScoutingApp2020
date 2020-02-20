using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage.MatchSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class scoutMain : ContentView
    {
        int ballInt = 0;
        public List<EventItem> eventList = new List<EventItem>();
        public Stopwatch timeMonitor;

        public scoutMain()
        {
            InitializeComponent();
        }

        private void Pick_Clicked(object sender, EventArgs e)
        {
            bool success = changeBallNum(1);
            eventList.Add(new EventItem(0, timeMonitor.Elapsed));

        }

        private void Lower_Clicked(object sender, EventArgs e)
        {
            bool success = changeBallNum(-1);
            eventList.Add(new EventItem(1, timeMonitor.Elapsed));

        }


        private void Outer_Clicked(object sender, EventArgs e)
        {
            bool success = changeBallNum(-1);
            eventList.Add(new EventItem(2, timeMonitor.Elapsed));

        }
        private void Inner_Clicked(object sender, EventArgs e)
        {
            bool success = changeBallNum(-1);
            eventList.Add(new EventItem(3, timeMonitor.Elapsed));

        }

        private void Miss_Clicked(object sender, EventArgs e)
        {
            bool success = changeBallNum(-1);
            eventList.Add(new EventItem(4, timeMonitor.Elapsed));

        }

        /// <summary>
        /// change the number of ball when a button is clicked
        /// </summary>
        /// <param name="ballDif"> number of balls changed </param>
        /// <returns> whether a change is possible </returns>
        private bool changeBallNum(int ballDif)
        {
            Undoer.IsEnabled = true;
            int result = ballInt + ballDif;
            if (result < 0 || result > 5)
            {
                return false;
            }
            ballInt = result;
            CurrentBall.Text = ballInt + "";
            return true;
        }

        private void Undo_Clicked(object sender, EventArgs e)
        {
            if (eventList.Count == 0)
            {
                return;
            }

            EventItem lastEvent = eventList[eventList.Count - 1];
            if (lastEvent.type == 0)
            {
                changeBallNum(-1);
            }
            else
            {
                changeBallNum(1);
            }
            eventList.RemoveAt(eventList.Count - 1);

            if (eventList.Count == 0)
            {
                Undoer.IsEnabled = false;
            }
        }
    }
}