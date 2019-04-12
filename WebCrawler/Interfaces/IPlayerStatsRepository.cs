using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawler.Interfaces
{
    public interface IPlayerStatsRepository
    {
        void SaveHighLevelStatsForPlayer(Models.PlayerStats PlayerModel);


        void SaveMatchStats(Models.MatchStatsPerPlayer MatchStats);

    }
}
