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
        private List<EventItem> eventList = new List<EventItem>();
        public Stopwatch timeMonitor;

        public scoutMain()
        {
            InitializeComponent();
        }

        private void Pick_Clicked(object sender, EventArgs e)
        {
            int t = 0;
            changeBallAssist(DataConstants.typeToBallChanged[t], t);

        }

        private void Lower_Clicked(object sender, EventArgs e)
        {
            int t = 1;
            changeBallAssist(DataConstants.typeToBallChanged[t], t);

        }


        private void Outer_Clicked(object sender, EventArgs e)
        {
            int t = 2;
            changeBallAssist(DataConstants.typeToBallChanged[t], t);
        }


        private void Inner_Clicked(object sender, EventArgs e)
        {
            int t = 3;
            changeBallAssist(DataConstants.typeToBallChanged[t], t);
        }
        private void Miss_Clicked(object sender, EventArgs e)
        {
            int t = 4;
            changeBallAssist(DataConstants.typeToBallChanged[t], t);
        }
        internal void setLocEventList(ScoutedInfo fullScout)
        {
            eventList = fullScout.eventList;
        }

        /// <summary>
        /// helper method to change the ball number through button clicks
        /// </summary>
        /// <param name="ballDif"></param>
        /// <param name="type"></param>
        private void changeBallAssist(int ballDif, int type)
        {
            bool success = changeBallNum(ballDif);
            if (success)
            {
                if (eventList.Count > 0)
                {
                    if (eventList[eventList.Count - 1].type == type)
                    {
                        eventList[eventList.Count - 1].spans.Add(timeMonitor.Elapsed);
                        return;
                    }
                }
                eventList.Add(new EventItem(type, timeMonitor.Elapsed));
            }
        }

        /// <summary>
        /// change the number of ball when a button is clicked
        /// </summary>
        /// <param name="ballDif"> number of balls changed </param>
        /// <returns> whether a change is possible </returns>
        private bool changeBallNum(int ballDif)
        {
            int result = ballInt + ballDif;
            if (result < 0 || result > 5)
            {
                return false;
            }
            Undoer.IsEnabled = true;
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
            changeBallNum(-lastEvent.ballChanged);
            lastEvent.spans.RemoveAt(lastEvent.spans.Count - 1);
            if (lastEvent.spans.Count == 0)
            {
                eventList.RemoveAt(eventList.Count - 1);
            }

            if (eventList.Count == 0)
            {
                Undoer.IsEnabled = false;
            }
        }

        public void setEventList(ScoutedInfo scouted)
        {
            scouted.eventList = eventList;
        }
    }
}