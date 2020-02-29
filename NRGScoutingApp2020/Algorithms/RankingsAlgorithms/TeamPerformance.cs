using NRGScoutingApp2020.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Algorithms.RankingsAlgorithms
{
    public class TeamPerformance
    {
        private int teamNum;
        private CompetitionClass comp;
        private List<ScoutedInfo> teamInfos = new List<ScoutedInfo>();
        public TeamPerformance(CompetitionClass competition, Dictionary<ScoutedInfo, int> infos, int num)
        {
            comp = competition;
            teamNum = num;
            foreach (ScoutedInfo inf in infos.Keys)
            {
                if (infos[inf] == teamNum)
                {
                    teamInfos.Add(inf);
                }
            }
            teamNum = num;
        }

        public List<Match> GetMatches()
        {
            List<Match> matches = new List<Match>();
            foreach (Match m in comp.matchesList)
            {
                if (m.isFilled)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (m.blueAlliance[i] == teamNum)
                        {
                            if (m.TeamsScouted[i] != null)
                            {
                                matches.Add(m);
                            }
                        }
                        if (m.redAlliance[i] == teamNum)
                        {
                            if (m.TeamsScouted[i + 3] != null)
                            {
                                matches.Add(m);
                            }
                        }
                    }
                }
            }
            return matches;
        }

        public double getValue(int t)
        {
            switch (t)
            {
                case 0:
                    return accuracyValue();
                case 1:
                case 2:
                case 3:
                    return shootNumberValue(t);
                case 4:
                    return climbValue();
                default:
                    return -1;
            }
        }

        private double climbValue()
        {
            double totalValue = 0;
            int count = 0;
            foreach (ScoutedInfo inf in teamInfos)
            {
                totalValue += inf.climbPick;
                count ++;
            }
            if (count == 0)
            {
                return -1;
            }
            else
            {
                return totalValue / count;
            }
        }

        private double shootNumberValue(int t)
        {
            double totalValue = 0;
            int count = 0;
            foreach (ScoutedInfo inf in teamInfos)
            {
                foreach (EventItem itm in inf.eventList)
                {
                    if (itm.type == t)
                    {
                        totalValue ++;
                    }
                }
                count ++;
            }
            if (count == 0)
            {
                return -1;
            }
            else
            {
                return totalValue / count;
            }
        }

        private double accuracyValue()
        {

            double totalValue = 0;
            int attempt = 0;
            foreach (ScoutedInfo inf in teamInfos)
            {
                foreach (EventItem itm in inf.eventList)
                {
                    if (itm.type > 0)
                    {
                        attempt ++;
                        if (itm.type <= 3)
                        {
                            totalValue ++;
                        }
                    }
                }
            }
            if (attempt == 0)
            {
                return -1;
            }
            else
            {
                return totalValue / attempt;
            }
        }
    }
}
