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
        public int Number { get; set; }

        // parameters below
        public ScoutedInfo(int matchNum)
        {
            Number = matchNum;
        }

    }
}
