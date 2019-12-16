using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Storages
{
    public class MatchEventClass
    {
        public string name { get; set; }
        public string date { get; set; }
        public string color { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
