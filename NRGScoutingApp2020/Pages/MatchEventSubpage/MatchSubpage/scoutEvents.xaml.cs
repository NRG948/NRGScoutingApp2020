using NRGScoutingApp2020.Algorithms;
using NRGScoutingApp2020.Data;
using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage.MatchSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class scoutEvents : ContentPage
    {
        Stopwatch timeMonitor = new Stopwatch();
        TimeSpan timee;
        TimeSpan endTimee = new TimeSpan(0, 2, 30);
        bool isScoutMain = true;

        Match thisMatch;
        int matchPos;

        bool newScout;
        ScoutedInfo fullScout;
        public scoutEvents(Match m, int pos)
        {
            InitializeComponent();
            thisMatch = m;
            matchPos = pos;
            eventMain.timeMonitor = timeMonitor;
            newScout = true;
            fullScout = new ScoutedInfo();
        }
        public scoutEvents(ScoutedInfo inf)
        {
            InitializeComponent();
            eventMain.timeMonitor = timeMonitor;
            finishBtn.Text = "Save";
            newScout = false;
            fullScout = inf;
            eventMain.setLocEventList(fullScout);
            eventParameters.setLocParameters(fullScout);
        }

        public scoutEvents(ScoutedInfo inf, bool isPara)
        {
            InitializeComponent();
            eventMain.timeMonitor = timeMonitor;
            finishBtn.Text = "Save";
            newScout = false;
            fullScout = inf;
            eventMain.setLocEventList(fullScout);
            eventParameters.setLocParameters(fullScout);
            if (isPara)
            {
                switchVieAction();
            }
        }
        /// <summary>
        /// Start/Pause the stopwatch to indicate the time 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void watchClicker_Clicked(object sender, EventArgs e)
        {
            if (timeMonitor.IsRunning)
            {
                timeMonitor.Stop();
                watchClicker.Text = "Start";
            }
            else
            {
                timeMonitor.Start();
                watchClicker.Text = "Pause";
                Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
                {
                    timee = timeMonitor.Elapsed;

                    if (TimeSpan.Compare(timee, endTimee) >= 0)
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            watchStop.Text = "2:30:000";
                            watchClicker.Text = "Ended";
                            watchClicker.IsEnabled = false;
                            matchProgress.Progress = 1;
                        });
                        return false;
                    }

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        watchStop.Text = string.Format("{0}:{1:00}:{2:000}", timee.Minutes, timee.Seconds, timee.Milliseconds);
                        matchProgress.Progress = timee.TotalMilliseconds / endTimee.TotalMilliseconds;
                    });

                    return timeMonitor.IsRunning;
                });
            }
        }

        /// <summary>
        /// reset the timer in case the scouter started early
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Resetter_Clicked(object sender, EventArgs e)
        {
            timeMonitor.Reset();
            watchClicker.IsEnabled = true;
            watchClicker.Text = "Start";
            watchStop.Text = "0:00:000";
            matchProgress.Progress = 0;
        }

        /// <summary>
        /// switch between main view and parameter view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void switchView_Clicked(object sender, EventArgs e)
        {
            switchVieAction();
        }

        private void switchVieAction()
        {
            if (isScoutMain)
            {
                switchView.Text = DataConstants.main;
            }
            else
            {
                switchView.Text = DataConstants.parameter;
            }
            isScoutMain = !isScoutMain;
            eventMain.IsVisible = isScoutMain;
            eventParameters.IsVisible = !isScoutMain;

        }

        private void finishBtn_Clicked(object sender, EventArgs e)
        {
            eventMain.setEventList(fullScout);
            eventParameters.setParameters(fullScout);

            if (newScout)
            {
                thisMatch.TeamsScouted[matchPos] = fullScout;
                thisMatch.isFilled = true;
            }

                Navigation.PopAsync();
        }
    }
}