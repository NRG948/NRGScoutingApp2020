using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Data
{
    public class TeamPitResponse
    {
        public DateTime time { get; set; }
        public List<string> answers { get; set; }
        public TeamPitResponse ()
        {
            time = DateTime.Now;
            answers = new List<string>();
        }
    }
}
