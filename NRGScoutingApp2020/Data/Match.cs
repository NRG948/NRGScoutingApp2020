using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Data
{
    public class Match
    {

        public int number { get; set; }
        public DateTime date;
        private int[] blueAlliance = new int[3];
        private int[] redAlliance = new int[3];

        public bool isFilled = false;
        public ScoutedInfo[] BluesScouted = new ScoutedInfo[3];
        public ScoutedInfo[] RedsScouted = new ScoutedInfo[3];
        public Match()
        {
            date = DateTime.UtcNow;
        }

        /// <summary>
        /// Sets both sides of the alliance
        /// </summary>
        /// <param name="isBlueAlliance"></param>
        /// <param name="arr"></param>
        /// <returns> this Match object </returns>

        public Match setAlliance(bool isBlueAlliance, int[] arr)
        {
            if (arr.Length == 3)
            {
                if (isBlueAlliance)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        blueAlliance[i] = arr[i];
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        redAlliance[i] = arr[i];
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// Get the team number at a position of an alliance; 
        /// position must be between 1 to 3, else returns -1
        /// </summary>
        /// <param name="isBlueAlliance"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public int getTeamAtPos(bool isBlueAlliance, int position)
        {
            if (position < 1 || position > 3)
            {
                return -1;
            }

            if (isBlueAlliance)
            {
                return blueAlliance[position - 1];
            }
            else
            {
                return redAlliance[position - 1];
            }
        }

    }
}
