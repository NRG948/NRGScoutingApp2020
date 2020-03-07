using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Data.PitScoutClass
{
    public class PitScoutResponse
    {
        DateTime time { get; set; }
        List<string> entries { get; set; }
        public PitScoutResponse()
        {
            time = DateTime.Now;
            entries = new List<string>();
        }
    }
}
