using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NRGScoutingApp2020
{
    /// <summary>
    /// This is a class that stores a competition, containing the name of it,
    /// the date of it, and the list of matches in it.
    /// </summary>
    public class MatchEventClass
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public string color { get; set; }
        public ObservableCollection<Match> matchesList = new ObservableCollection<Match>();
        public MatchEventClass(DateTime Date)
        {
            date = Date;
        }

        public MatchEventClass()
        {
            date = DateTime.UtcNow;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
