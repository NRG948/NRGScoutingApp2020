using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NRGScoutingApp2020.Data;

namespace NRGScoutingApp2020.Pages.MatchEventSubpage.PitScoutSubpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PitScoutMain : ContentPage
    {
        List<Entry> entries = new List<Entry>();
        public PitScoutMain()
        {
            InitializeComponent();

            string[] questions = DataConstants.QUESTIONS;
            for (int i = 0; i < questions.Count(); i++)
            {
                Label q = new Label
                {
                    Text = questions[i]
                };

                Entry e = new Entry();

                entries.Add(e);

                questionLayout.Children.Add(q);
                questionLayout.Children.Add(e);
            }

        }

        private void CancelClicked(object sender, EventArgs e)
        {

        }

        private void SaveClicked(object sender, EventArgs e)
        {

        }
    }
}