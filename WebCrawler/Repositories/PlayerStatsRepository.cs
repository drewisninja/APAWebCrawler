using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WebCrawler.Interfaces;
using System.Data;




namespace WebCrawler.Repositories
{
    class PlayerStatsRepository : IPlayerStatsRepository
    {
        public void SaveHighLevelStatsForPlayer(Models.PlayerStats PlayerModel)
        {

            using (var db = new Models.PlayerStats())
            {
                db.Players.Add(new Models.Players { PlayerID = PlayerModel.tempPlayers.PlayerID, TeamID = PlayerModel.tempPlayers.TeamID, PlayerName = PlayerModel.tempPlayers.PlayerName });

                db.SaveChanges();
            }

        }

        public void SaveMatchStats(Models.MatchStatsPerPlayer MatchStats)
        {

        }

        public void SavePlayerBasicInfo(Models.PlayerStats PlayerModel)
        {
            using (var db = new Models.PlayerStats())
            {
                db.Players.Add(new Models.Players { PlayerID = PlayerModel.tempPlayers.PlayerID, TeamID = PlayerModel.tempPlayers.TeamID, PlayerName = PlayerModel.tempPlayers.PlayerName});

                db.SaveChanges();
            }
        }

    }
}
