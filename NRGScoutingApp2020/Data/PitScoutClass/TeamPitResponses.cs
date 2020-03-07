using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Data.PitScoutClass
{
    public class TeamPitResponses
    {
        public int teamNum { get; set; }
        public string teamName { get; set; }
        public string teamNameFormated { get 
            {
                return teamNum + " - " + teamName;
            } 
        }
        public List<PitScoutResponse> responses { get; set; } = new List<PitScoutResponse>();

        public TeamPitResponses(int n, string name)
        {
            teamNum = n;
            teamName = name;
        }
    }
}
