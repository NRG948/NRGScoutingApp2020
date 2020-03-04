using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Data
{
    public class Match
    {

        public int number { get; set; }
        public string matchNum { get { return "Match " + number; } }
        public int[] blueAlliance = new int[3];
        public int[] redAlliance = new int[3];

        public bool isFilled = false;
        public ScoutedInfo[] TeamsScouted = new ScoutedInfo[6];
        public Match()
        {
        }

        public Dictionary<int, ScoutedInfo> getInfosFormatted()
        {
            Dictionary<int, ScoutedInfo> formattedMatch = new Dictionary<int, ScoutedInfo>();
            for (int i = 0; i < 6; i++)
            {
                if (TeamsScouted[i] != null)
                {
                    formattedMatch.Add(i, TeamsScouted[i]);
                }

            }

            return formattedMatch;
        }

        public void setInfos(Dictionary<int, ScoutedInfo> formattedMatch)
        {
            foreach (KeyValuePair<int, ScoutedInfo> pair in formattedMatch)
            {
                TeamsScouted[pair.Key] = pair.Value;
            }
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

        public int indexOf (int teamNum)
        {
            for (int i = 0; i < 3; i++)
            {
                if (teamNum == blueAlliance[i])
                {
                    return i;
                }
                if (teamNum == redAlliance[i])
                {
                    return i + 3;
                }
            }
            return -1;
        }
    }
}
