using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRGScoutingApp2020.Algorithms.RankingsAlgorithms
{
    public class Ranker
    {

        Dictionary<ScoutedInfo, int> infs = new Dictionary<ScoutedInfo, int>();
        List<KeyValuePair<int, string>>[] ranks = new List<KeyValuePair<int, string>>[5];

        public Ranker(CompetitionClass competition)
        {
            infs = getInformations(competition);
        }

        /// <summary>
        /// Get all the information object in the competition
        /// </summary>
        /// <param name="comp"> the competition </param>
        /// <returns> the list of ScoutedInfo objects paired with the team number </returns>
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

        public Dictionary<ScoutedInfo, int> getInformations()
        {
            return infs;
        }

        public List<KeyValuePair<int, string>> competitionRank(int t)
        {
            if (t >= 5 || t < 0)
            {
                return new List<KeyValuePair<int, string>>();
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
        public static List<KeyValuePair<int, string>> competitionRank(Dictionary<ScoutedInfo, int> infos, int t)
        {
            List<KeyValuePair<int, string>> result;
            switch (t)
            {
                case 0:
                    result = accuracyRank(infos);
                    break;
                case 1:
                case 2:
                case 3:
                    result = shootNumberRank(infos, t);
                    break;
                case 4:
                    result = climbRank(infos);
                    break;
                default:
                    return new List<KeyValuePair<int, string>>();
            }
            return result;
        }

        public static List<KeyValuePair<int, string>> shootNumberRank(Dictionary<ScoutedInfo, int> infos, int t)
        {
            Dictionary<int, double> teamValueTotal = new Dictionary<int, double>();
            Dictionary<int, int> teamCount = new Dictionary<int, int>();
            Dictionary<int, double> teamValueAvg = new Dictionary<int, double>();

            foreach (ScoutedInfo inf in infos.Keys)
            {
                int teamNum = infos[inf];

                if (!teamValueTotal.ContainsKey(teamNum))
                {
                    teamValueTotal[teamNum] = 0;
                    teamCount[teamNum] = 0;
                }

                foreach (EventItem evt in inf.eventList)
                {
                    if (evt.type == t)
                    {
                        teamValueTotal[teamNum] += evt.count;
                    }

                }

                teamCount[teamNum] ++;
            }

            foreach (int k in teamValueTotal.Keys)
            {
                teamValueAvg.Add(k, teamValueTotal[k] / teamCount[k]);
            }

            List<KeyValuePair<int, double>> teamValTolList = teamValueAvg.ToList();

            teamValTolList.Sort((tma, tmb) => tmb.Value.CompareTo(tma.Value));

            return teamValTolList.Select(pair => new KeyValuePair<int, string>(pair.Key, pair.Value + "")).ToList();
        }

        public static List<KeyValuePair<int, string>> climbRank(Dictionary<ScoutedInfo, int> infos)
        {
            Dictionary<int, double> teamValueTotal = new Dictionary<int, double>();
            Dictionary<int, int> teamCount = new Dictionary<int, int>();
            Dictionary<int, double> teamValueAvg = new Dictionary<int, double>();

            foreach (ScoutedInfo inf in infos.Keys)
            {
                int teamNum = infos[inf];

                if (!teamValueTotal.ContainsKey(teamNum))
                {
                    teamValueTotal[teamNum] = 0;
                    teamCount[teamNum] = 0;
                }

                teamValueTotal[teamNum] += inf.climbPick;

                teamCount[teamNum] ++;
            }

            foreach (int k in teamValueTotal.Keys)
            {
                teamValueAvg.Add(k, teamValueTotal[k] / teamCount[k]);
            }

            List<KeyValuePair<int, double>> teamValTolList = teamValueAvg.ToList();

            teamValTolList.Sort((tma, tmb) => tmb.Value.CompareTo(tma.Value));

            return teamValTolList.Select(pair => new KeyValuePair<int, string>(pair.Key, pair.Value + "")).ToList();
        }

        public static List<KeyValuePair<int, string>> accuracyRank(Dictionary<ScoutedInfo, int> infos)
        {
            Dictionary<int, double> madeIn = new Dictionary<int, double>();
            Dictionary<int, int> madeTotal = new Dictionary<int, int>();
            Dictionary<int, double> accuracy = new Dictionary<int, double>();

            foreach (ScoutedInfo inf in infos.Keys)
            {
                int teamNum = infos[inf];

                if (!madeIn.ContainsKey(teamNum))
                {
                    madeIn[teamNum] = 0;
                    madeTotal[teamNum] = 0;
                }

                foreach (EventItem evt in inf.eventList)
                {
                    if (evt.type > 0)
                    {
                        madeTotal[teamNum] += evt.count;
                        if (evt.type <= 3)
                        {
                            madeIn[teamNum] += evt.count;
                        }
                    }

                }

            }

            foreach (int k in madeIn.Keys)
            {
                if (madeTotal[k] > 0)
                {
                    accuracy.Add(k, madeIn[k] / madeTotal[k]);
                }
                else
                {
                    accuracy.Add(k, 0);
                }
            }

            List<KeyValuePair<int, double>> teamValTolList = accuracy.ToList();

            teamValTolList.Sort((tma, tmb) => tmb.Value.CompareTo(tma.Value));

            return teamValTolList.Select(pair => new KeyValuePair<int, string>(pair.Key, pair.Value.ToString("P", CultureInfo.InvariantCulture))).ToList();
        }
    }
}
