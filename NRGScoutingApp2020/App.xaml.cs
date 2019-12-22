using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NRGScoutingApp2020
{
    public partial class App : Application
    {
        public string textbox = "";
        public static Dictionary<int, String> teamsList = new Dictionary<int, String>();
        public string text = "text";
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            if (Properties.ContainsKey(text))
            {
                textbox = (string) Properties[text];
            }
        }

        protected override void OnSleep()
        {
            Properties[text] = textbox;
        }

        protected override void OnResume()
        {
        }
    }
}
