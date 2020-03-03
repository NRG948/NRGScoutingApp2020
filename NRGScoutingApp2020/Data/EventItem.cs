using System;
using System.Collections.Generic;
using System.Text;
using NRGScoutingApp2020.Data;

namespace NRGScoutingApp2020.Data
{
    /// <summary>
    /// Class for storing the individual event happened when scouting
    /// </summary>
    public class EventItem
    {
        public int type { get; set; }
        public List<TimeSpan> spans { get; set; }
        public int ballChanged { get; set; }
        public string typeStr { get { return DataConstants.actionTypeList[type]; } }
        public string firstTime { get { return spans[0].ToString(); } }
        public int count { get { return spans.Count; } }


        public EventItem (int t, TimeSpan s)
        {
            type = t;
            spans = new List<TimeSpan>();
            spans.Add(s);
            ballChanged = DataConstants.typeToBallChanged[type];
        }

        /// <summary>
        /// get the point value for this event
        /// </summary>
        /// <returns></returns>
        public int getPoint()
        {
            return 0;
        }
    }
}
