using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NRGScoutingApp2020
{
    public partial class App : Application
    {
        public string textbox = "";
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
