using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NRGScoutingApp2020.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            MatchScout mtsc = new MatchScout();
            Children.Add(new NavigationPage(mtsc)
            {
                BarBackgroundColor = Color.IndianRed,
                BarTextColor = Color.White,
                Title = "Match Scout"
            });
            PitScout ptsc = new PitScout();
            Children.Add(new NavigationPage(ptsc)
            {
                BarBackgroundColor = Color.IndianRed,
                BarTextColor = Color.White,
                Title = "Pit Scout"
            });
        }
    }
}