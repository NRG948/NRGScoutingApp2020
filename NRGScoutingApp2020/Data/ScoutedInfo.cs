using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Data
{
    /// <summary>
    /// class for matches scouted by scouters
    /// </summary>
    public class ScoutedInfo
    {
        public bool AutoInitiation { get; set; }
        public int climbPick { get; set; }
        public bool controlRotational { get; set; }
        public bool controlPositional { get; set; }
        public double deathRange { get; set; }
        public int penaltyPick { get; set; }
        public string commentt { get; set; }
        public int magnitudeDefend { get; set; }
        public int magnitudeDefended { get; set; }

        public List<EventItem> eventList { get; set; }

    // parameters below

}
}
