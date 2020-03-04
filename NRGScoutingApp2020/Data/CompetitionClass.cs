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
        public string eventKey { get; set; }
        public List<Match> matchesList = new List<Match>();

        public CompetitionClass()
        {
        }

        public Dictionary<int, Dictionary<int, ScoutedInfo>> getMatchesFormatted()
        {
            Dictionary<int, Dictionary<int, ScoutedInfo>> compFormatted = new Dictionary<int, Dictionary<int, ScoutedInfo>>();
            foreach (Match m in matchesList)
            {
                if (m.isFilled)
                {
                    compFormatted.Add(m.number, m.getInfosFormatted());
                }
            }
            return compFormatted;
        }

        public void setMatches(Dictionary<int, Dictionary<int, ScoutedInfo>> compFormatted)
        {
            foreach (KeyValuePair<int, Dictionary<int, ScoutedInfo>> pair in compFormatted)
            {
                matchesList[pair.Key].setInfos(pair.Value);
            }

        }
        public override string ToString()
        {
            return name;
        }
    }
}
