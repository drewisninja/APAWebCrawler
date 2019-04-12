using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawler.Models
{
    public class PlayerStats
    {
        public string PlayerID { get; set; }

        public string PlayerName { get; set; }

        public string SkillLevel { get; set; }

        public string MatchsWonPlayed { get; set; }

        public string WinPercentage { get; set; }

        public string PointPerMatch { get; set; }

        public string PointsAgainst { get; set; }
    }
}
