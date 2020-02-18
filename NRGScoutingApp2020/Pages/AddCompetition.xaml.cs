﻿using NRGScoutingApp2020.Algorithms;
using NRGScoutingApp2020.Pages.MatchEventSubpage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NRGScoutingApp2020.App;

namespace NRGScoutingApp2020.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// Page for pulling a list of conpetitions
    /// </summary>
    public partial class AddCompetition : ContentPage
    {
        public AddCompetition()
        {
            InitializeComponent();
            if (eventsKeyName.Count == 0)
            {
                DownloadData.getEventsNames();
                CacheData.CacheEventsList(eventsKeyName);
            }
            competitions.ItemsSource = eventsKeyName;
        }

        async private void competitions_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                KeyValuePair<string, string> pair = (KeyValuePair<string, string>) e.Item;
                eventsKeyName.Remove(pair.Key);
                CompetitionClass competition = DownloadData.getEventSpecific(pair.Key);
                if (competition.matchesList.Count != 0)
                {
                    competition.name = pair.Value;
                    eventsListObj.Add(competition);
                    CacheData.CacheOneEvent(competition);
                    await Navigation.PushAsync(new MatchList(competition)).ConfigureAwait(false);
                    Navigation.RemovePage(this);
                }
                else
                {
                    await DisplayAlert("Error", DataConstants.EmptyCompetition, "Sksksk").ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Update list when the text in search bar is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SEARCH_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(e.NewTextValue) || String.IsNullOrEmpty(e.NewTextValue))
            {
                competitions.ItemsSource = eventsKeyName;
            }
            else
            {
                competitions.ItemsSource = eventsKeyName.Where(pair => pair.Value.ToLower().Trim().Contains(e.NewTextValue.ToLower().Trim()));
            }
        }
        private bool ContainsKey(ObservableCollection<CompetitionClass> comps, string key)
        {
            foreach (CompetitionClass comp in comps)
            {
                if (comp.eventKey == key)
                {
                    return true;
                }
            }
            return false;
        }
    }
}