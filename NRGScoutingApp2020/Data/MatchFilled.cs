using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Data
{
    /// <summary>
    /// class for matches scouted by scouters
    /// </summary>
    public class MatchFilled
    {
        public int Number { get; set; }

        public int Position { get; set; }

        // parameters below
        public MatchFilled(int matchNum, int pos)
        {
            Number = matchNum;
            Position = pos;
        }

    }
}
