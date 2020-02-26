using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRGScoutingApp2020.Algorithms.RankingsAlgorithms
{
    public class Ranker
    {

        Dictionary<ScoutedInfo, int> infs = new Dictionary<ScoutedInfo, int>();
        List<KeyValuePair<int, double>>[] ranks = new List<KeyValuePair<int, double>>[5];

        public Ranker(CompetitionClass competition)
        {
            infs = getInformations(competition);
        }


        public static Dictionary<ScoutedInfo, int> getInformations(CompetitionClass comp)
        {
            Dictionary<ScoutedInfo, int> infos = new Dictionary<ScoutedInfo, int>();
            foreach (Match m in comp.matchesList)
            {
                if (m.isFilled)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (m.TeamsScouted[i] != null)
                        {
                            int teamNum = i < 2 ? m.blueAlliance[i] : m.redAlliance[i - 3];
                            infos.Add(m.TeamsScouted[i], teamNum);
                        }
                    }
                }
            }
            return infos;
        }

        public List<KeyValuePair<int, double>> competitionRank(int t)
        {
            if (t >= 5 || t < 0)
            {
                return new List<KeyValuePair<int, double>>();
            }
            if (ranks[t] == null)
            {
                ranks[t] = competitionRank(infs, t);
            }
            return ranks[t];
        }

        /// <summary>
        /// rank a list of teams by their performance in a competition
        /// </summary>
        /// <param name="comp"> the competition </param>
        /// <param name="type"> the type of rank </param>
        /// <returns> the list of teams by their numbers </returns>
        public static List<KeyValuePair<int, double>> competitionRank(Dictionary<ScoutedInfo, int> infos, int t)
        {

            switch (t)
            {
                case 0:
                    break;
                case 1:
                    return shootNumberRank(infos, t);
                case 2:
                    return shootNumberRank(infos, t);
                case 3:
                    return shootNumberRank(infos, t);
                case 4:
                    break;
                default:
                    return new List<KeyValuePair<int, double>>();
            }
            return null;
        }

        public static List<KeyValuePair<int, double>> shootNumberRank(Dictionary<ScoutedInfo, int> infos, int t)
        {

            List<int> teams;
            Dictionary<int, double> teamValueTotal = new Dictionary<int, double>();
            Dictionary<int, int> teamCount = new Dictionary<int, int>();

            foreach (ScoutedInfo inf in infos.Keys)
            {
                int teamNum = infos[inf];

                foreach (EventItem evt in inf.eventList)
                {
                    if (evt.type == t)
                    {
                        if (teamValueTotal.ContainsKey(teamNum))
                        {
                            teamValueTotal[teamNum] += 1;
                        }
                        else
                        {
                            teamValueTotal.Add(teamNum, 1);
                        }
                    }

                }
                if (teamCount.ContainsKey(teamNum))
                {
                    teamCount[teamNum] += 1;
                }
                else
                {
                    teamCount.Add(teamNum, 1);
                }
            }

            foreach (int k in teamValueTotal.Keys)
            {
                teamValueTotal[k] /= teamCount[k];
            }

            List<KeyValuePair<int, double>> teamValTolList = teamValueTotal.ToList();

            teamValTolList.Sort((tma, tmb) => tma.Value.CompareTo(tmb.Value));

            return teamValTolList;
        }
    }
}
