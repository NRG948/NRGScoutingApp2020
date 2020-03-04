using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NRGScoutingApp2020.Algorithms;
using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NRGScoutingApp2020.App;
using Xamarin.Essentials;

namespace NRGScoutingApp2020.Pages.DataManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataManage : ContentPage
    {
        private bool isImport = true;
        private string shareText = "";
        public DataManage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            CacheData.CacheEvents(eventsListObj);
            base.OnDisappearing();
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
                Dictionary<string, Dictionary<int, Dictionary<int, ScoutedInfo>>> compsFormatted =
                    new Dictionary<string, Dictionary<int, Dictionary<int, ScoutedInfo>>>();
                foreach (CompetitionClass comp in eventsListObj)
                {
                    Dictionary<int, Dictionary<int, ScoutedInfo>> compF = comp.getMatchesFormatted();
                    if (compF.Count > 0)
                    {
                        compsFormatted.Add(comp.eventKey, comp.getMatchesFormatted());
                    }
                }
                shareText = JsonConvert.SerializeObject(compsFormatted);
                exportDetailLabel.Text = "You will share data of " + compsFormatted.Count + " competitions";
            }
        }

        private void importTextEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                importDetailLabel.Text = "";
            }
            else
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
                Dictionary<string, Dictionary<int, Dictionary<int, ScoutedInfo>>> compsFormatted = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<int, Dictionary<int, ScoutedInfo>>>>(importTextEditor.Text);

                string choice = "";

                foreach (KeyValuePair<string, Dictionary<int, Dictionary<int, ScoutedInfo>>> compF in compsFormatted)
                {
                    if (oldCompKeys.Contains(compF.Key))
                    {
                        CompetitionClass oldcomp = eventsListObj[oldCompKeys.IndexOf(compF.Key)];
                        foreach (KeyValuePair<int, Dictionary<int, ScoutedInfo>> matchF in compF.Value)
                        {
                            foreach(KeyValuePair<int, ScoutedInfo> scoutedF in matchF.Value)
                            {
                                if (oldcomp.matchesList[matchF.Key].TeamsScouted[scoutedF.Key] != null)
                                {
                                    if (choice.Length == 0)
                                    {
                                        choice = await DisplayActionSheet(
                                            "Conflict File at " + oldcomp.name + " Match No." + (matchF.Key + 1),
                                            "Ignore All", null, "Overwrite", "Overwrite All", "Ignore")
                                            .ConfigureAwait(true);
                                    }
                                }
                            }
                            switch (choice)
                            {
                                case "Overwrite All":
                                    oldcomp.matchesList[matchF.Key].setInfos(matchF.Value);
                                    break;
                                case "Overwrite":
                                    oldcomp.matchesList[matchF.Key].setInfos(matchF.Value);
                                    choice = "";
                                    break;
                                case "Ignore":
                                    choice = "";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        CompetitionClass comp = DownloadData.getEventSpecific(compF.Key);
                        comp.setMatches(compF.Value);
                        eventsListObj.Add(comp);
                        CacheData.CacheOneEvent(comp);
                    }
                }


                //ObservableCollection<CompetitionClass> newComps = 
                //    JsonConvert.DeserializeObject<ObservableCollection<CompetitionClass>>(importTextEditor.Text);

                //string choice = "";

                //foreach (CompetitionClass comp in newComps)
                //{
                //    if (oldCompKeys.Contains(comp.eventKey))
                //    {
                //        CompetitionClass oldComp = eventsListObj[oldCompKeys.IndexOf(comp.eventKey)];
                //        for (int num = 0; num < comp.matchesList.Count; num++)
                //        {
                //            for (int pos = 0; pos < 6; pos ++)
                //            {
                //                if (comp.matchesList[num].TeamsScouted[pos] != null)
                //                {
                //                    if (oldComp.matchesList[num].TeamsScouted[pos] != null)
                //                    {
                //                        if (choice.Length == 0)
                //                        {
                //                            choice = await DisplayActionSheet(
                //                                "Conflict file at " + comp.name + " match No." + (num + 1),
                //                                "Ignore all", null, "Overwrite", "Overwrite all", "Ignore")
                //                                .ConfigureAwait(true);
                //                            switch (choice)
                //                            {
                //                                case "Overwrite":
                //                                    oldComp.matchesList[num].TeamsScouted[pos] = comp.matchesList[num].TeamsScouted[pos];
                //                                    choice = "";
                //                                    break;
                //                                case "Ignore":
                //                                    choice = "";
                //                                    break;
                //                                default:
                //                                    break;
                //                            }
                //                        }
                //                        if (choice == "Overwrite all")
                //                        {
                //                            oldComp.matchesList[num].TeamsScouted[pos] = comp.matchesList[num].TeamsScouted[pos];
                //                        }
                //                    }
                //                    else
                //                    {
                //                        oldComp.matchesList[num].TeamsScouted[pos] = comp.matchesList[num].TeamsScouted[pos];
                //                    }
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        eventsListObj.Add(comp);
                //        CacheData.CacheOneEvent(comp);
                //    }
                //}

            }
            catch (Exception)
            {
                DisplayAlert("ERROR", "Invalid Format!", "sksksk");
            }
            importTextEditor.Text = "";
        }

        /// <summary>
        /// Share Competitions Json by showing options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void exportAsShare(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = shareText
            });
        }
        /// <summary>
        /// Copy competition json to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void exportAsCopy(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(shareText).ConfigureAwait(false);
        }
        
    }
}