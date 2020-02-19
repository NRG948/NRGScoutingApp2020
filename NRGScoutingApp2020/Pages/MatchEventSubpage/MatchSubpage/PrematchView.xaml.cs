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
    public partial class PrematchView : ContentView
    {
        public int selectID = -1;
        public Match matchHere;
        public PrematchView(Match m, bool isCreate)
        {
            InitializeComponent();
            matchHere = m;
            // inefficient coding!!!
            if (isCreate)
            {
                updateCreate();
            }
        }

        public PrematchView()
        {

        }

        public void updateCreate()
        {
            int btnID = 0;
            for (int i = 0; i < 3; i++)
            {
                Button btn = new Button
                {
                    Text = DataConstants.canSelect,
                    IsEnabled = (matchHere.BluesScouted[i] == null),
                    StyleId = btnID + ""
                };
                btn.Clicked += OnDynamicBtnClicked;
                btnID += 1;
                selection.Children.Add(btn, 0, i + 1);
            }
            for (int i = 0; i < 3; i++)
            {
                Button btn = new Button
                {
                    Text = DataConstants.canSelect,
                    IsEnabled = (matchHere.RedsScouted[i] == null),
                    StyleId = btnID + ""
                };
                btn.Clicked += OnDynamicBtnClicked;
                btnID += 1;
                selection.Children.Add(btn, 1, i + 1);
            }
        }
        private void OnDynamicBtnClicked(object sender, EventArgs e)
        {
            if (selectID >= 3)
            {
                Button oldBtn = (Button) selection.Children.Where(obj => Grid.GetColumn(obj) == 1 
                                                                && Grid.GetRow(obj) == selectID - 2).FirstOrDefault();
                oldBtn.IsEnabled = true;
                oldBtn.Text = DataConstants.canSelect;
            }
            else if (selectID >= 0)
            {
                Button oldBtn = (Button) selection.Children.Where(obj => Grid.GetColumn(obj) == 0
                                                               && Grid.GetRow(obj) == selectID + 1).FirstOrDefault();
                oldBtn.IsEnabled = true;
                oldBtn.Text = DataConstants.canSelect;
            }

            Button btn = sender as Button;
            selectID = int.Parse(btn.StyleId);
            btn.IsEnabled = false;
            btn.Text = DataConstants.selecting;
        }

        public View GetView(int col, int row)
        {
            foreach (View v in selection.Children) if ((col == Grid.GetColumn(v)) && (row == Grid.GetRow(v))) return v;
            return null;
        }
    }
}