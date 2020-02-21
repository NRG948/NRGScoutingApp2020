using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NRGScoutingApp2020.Algorithms;
using NRGScoutingApp2020.Data;
using Plugin.Share;
using Plugin.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NRGScoutingApp2020.App;

namespace NRGScoutingApp2020.Pages.DataManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataManage : ContentPage
    {
        private bool isImport = true;
        private string shareText;
        public DataManage()
        {
            InitializeComponent();
        }

        protected void OnDisappearing()
        {

        }

        private void ChangeImportExport(object sender, EventArgs e)
        {
            isImport = !isImport;
            importBtn.IsEnabled = !isImport;
            exportBtn.IsEnabled = isImport;
            importFrame.IsVisible = isImport;
            exportFrame.IsVisible = !isImport;
            if (isImport)
            {

            } else
            {
                shareText = JsonConvert.SerializeObject(eventsListObj);
                exportDetailLabel.Text = "You will share data of " + eventsListObj.Count + " competitions";
            }
        }

        private void importTextEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                JArray arr = JArray.Parse(e.NewTextValue);
                importDetailLabel.Text = "This contains " + arr.Count + " competitions";
                importDetailLabel.TextColor = Color.Black;
            }
            catch (Exception)
            {
                importDetailLabel.Text = "ERROR";
                importDetailLabel.TextColor = Color.Red;
            }
        }

        /// <summary>
        /// attempt to merge outside data with inside data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void importConfirm(object sender, EventArgs e)
        {
            try
            {
                List<string> oldCompKeys = new List<string>();
                foreach (CompetitionClass comp in eventsListObj)
                {
                    oldCompKeys.Add(comp.eventKey);
                }
                ObservableCollection<CompetitionClass> newComps = 
                    JsonConvert.DeserializeObject<ObservableCollection<CompetitionClass>>(importTextEditor.Text);

                string choice = "";

                foreach (CompetitionClass comp in newComps)
                {
                    if (oldCompKeys.Contains(comp.eventKey))
                    {
                        CompetitionClass oldComp = eventsListObj[oldCompKeys.IndexOf(comp.eventKey)];
                        for (int num = 0; num < comp.matchesList.Count; num++)
                        {
                            for (int pos = 0; pos < 6; pos ++)
                            {
                                if (comp.matchesList[num].TeamsScouted[pos] != null)
                                {
                                    if (oldComp.matchesList[num].TeamsScouted[pos] != null)
                                    {
                                        if (choice.Length == 0)
                                        {
                                            choice = await DisplayActionSheet(
                                                "Conflict file at " + comp.name + " match No." + (num + 1),
                                                "Ignore all", null, "Overwrite", "Overwrite all", "Ignore")
                                                .ConfigureAwait(false);
                                            switch (choice)
                                            {
                                                case "Overwrite":
                                                    oldComp.matchesList[num].TeamsScouted[pos] = comp.matchesList[num].TeamsScouted[pos];
                                                    choice = "";
                                                    break;
                                                case "Ignore":
                                                    choice = "";
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        if (choice == "Overwrite all")
                                        {
                                            oldComp.matchesList[num].TeamsScouted[pos] = comp.matchesList[num].TeamsScouted[pos];
                                        }
                                    }
                                    else
                                    {
                                        oldComp.matchesList[num].TeamsScouted[pos] = comp.matchesList[num].TeamsScouted[pos];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        eventsListObj.Add(comp);
                        CacheData.CacheOneEvent(comp);
                    }
                }
            }
            catch (Exception)
            {
                DisplayAlert("ERROR", "Invalid Format!", "sksksk");
            }
        }

        /// <summary>
        /// Share Competitions Json by showing options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportAsShare(object sender, EventArgs e)
        {
            if (!CrossShare.IsSupported)
            {
                DisplayAlert("Sorry", "This device does not support the share option", "sksksk");
            } 
            else
            {
                CrossShare.Current.Share(new ShareMessage {
                    Text = shareText,
                    Title = "Competition Data"
                });

            }
        }
        /// <summary>
        /// Copy competition json to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportAsCopy(object sender, EventArgs e)
        {
            
            if (!CrossShare.Current.SupportsClipboard)
            {
                DisplayAlert("Sorry", "This device does not support the copy option", "sksksk");
            } 
            else
            {
                CrossShare.Current.SetClipboardText(shareText, "CompetitionData");
            }
        }
        
    }
}