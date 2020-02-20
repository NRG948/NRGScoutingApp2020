using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Data
{
    /// <summary>
    /// Class for storing the individual event happened when scouting
    /// </summary>
    public class EventItem
    {
        public int type;
        public TimeSpan span;

        public EventItem (int t, TimeSpan s)
        {
            type = t;
            span = s;
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
