using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public scoutEvents()
        {
            InitializeComponent();
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
                        });
                        return false;
                    }

                    MainThread.BeginInvokeOnMainThread(() => 
                    {
                        watchStop.Text = string.Format("{0}:{1:00}:{2:000}", timee.Minutes, timee.Seconds, timee.Milliseconds);
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
        }

        private void switchView_Clicked(object sender, EventArgs e)
        {
            if (isScoutMain)
            {
                switchView.Text = "Main";
            }
            else
            {
                switchView.Text = "Parameters";
            }
            isScoutMain = !isScoutMain;
            eventMain.IsVisible = isScoutMain;
            eventParameters.IsVisible = !isScoutMain;
        }

        private void finishBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}