using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NRGScoutingApp2020
{
    /// <summary>
    /// This is a class that stores a competition, containing the name of it,
    /// the date of it, the eventKey of it (BlueAlliance Format), and the list of matches in it.
    /// </summary>
    public class CompetitionClass
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public string eventKey { get; set; }

        public ObservableCollection<MatchFilled> matchesScouted = new ObservableCollection<MatchFilled>();
        public List<Match> matchesList = new List<Match>();

        public CompetitionClass()
        {
            date = DateTime.UtcNow;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
