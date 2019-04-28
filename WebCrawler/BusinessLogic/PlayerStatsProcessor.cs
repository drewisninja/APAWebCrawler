using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebCrawler.Interfaces;
using WebCrawler.Repositories;

namespace WebCrawler.BusinessLogic
{
    public class PlayerStatsProcessor 
    {
        IPlayerStatsRepository _IPlayerRepo;
        ChromeDriver _driver;
        string startURL;

        public PlayerStatsProcessor(ChromeDriver driver, string url)
        {
            _IPlayerRepo = new PlayerStatsRepository();
            this.startURL = url;
            this._driver = driver;
        }

        public void GetAllQualifiedTeamsURL()
        {
            _driver.Navigate().GoToUrl(this.startURL);
            System.Threading.Thread.Sleep(1000);

            var division = _driver.FindElements(By.TagName("option"));

            for (int i = 0; i < division.Count; i++)
            {
                var divisiontemp = _driver.FindElements(By.TagName("option"));

                var divisionURL = this.startURL + "/session/" + divisiontemp[i].GetAttribute("value").ToString();

                _driver.Navigate().GoToUrl(divisionURL);
                System.Threading.Thread.Sleep(1000);

                var singleDivisionURL = _driver.FindElementsByClassName("css-k8wt5j");

                for (int j = 0; j < singleDivisionURL.Count; j++)
                {

                    var singleDivisionURLtemp = _driver.FindElementsByClassName("css-k8wt5j");

                    singleDivisionURLtemp[j].Click();
                    System.Threading.Thread.Sleep(1000);


                    _driver.Navigate().Back();
                }

                _driver.Navigate().Back();
            }

        }

        public void ProcessPlayerHighLevelStats()
        {
            _driver.Navigate().GoToUrl(this.startURL);

            System.Threading.Thread.Sleep(1000);

            var teamList = _driver.FindElementsByClassName("division-standing");

            
            //var rostersBtn = driver.FindElementByXPath("//*[contains(text(), 'Rosters')]");
            //rostersBtn.Click();

            for (int i = 0; i < teamList.Count - 1; i++)
            {

                var newTeamList = _driver.FindElementsByClassName("division-standing");

                var newTeamID = newTeamList[i].GetAttribute("to");



                //Enter into team details
                newTeamList[i].Click();
                System.Threading.Thread.Sleep(2000);


                //Table of all names in the team
                var Players = _driver.FindElementByClassName("table-responsive");

                var singlePlayers = Players.FindElements(By.TagName("tr"));

                for (int j = 0; j < singlePlayers.Count - 1; j++)
                {
                    try
                    {
                        var player = singlePlayers[j].FindElements(By.TagName("td"));

                        Models.PlayerStats PlayerModel = new Models.PlayerStats();
                        PlayerModel.tempPlayers = new Models.Players();

                        var playerdiv = player[0].FindElements(By.TagName("div"));

                        PlayerModel.tempPlayers.PlayerName = playerdiv[0].Text;
                        PlayerModel.tempPlayers.PlayerID = Convert.ToInt32(playerdiv[1].Text.Replace("#",""));
                        PlayerModel.tempPlayers.TeamID = Convert.ToInt32(newTeamID.ToString().Replace("/oc/team/", ""));
                        //PlayerModel.SkillLevel = player[1].Text;
                        //PlayerModel.MatchsWonPlayed = player[2].Text;
                        //PlayerModel.WinPercentage = player[3].Text;
                        //PlayerModel.PointPerMatch = player[4].Text;
                        //PlayerModel.PointsAgainst = player[5].Text;

                        _IPlayerRepo.SavePlayerBasicInfo(PlayerModel);



                    }
                    catch (Exception ex) { }

                }


                //Back to Team List
                _driver.Navigate().Back();
                System.Threading.Thread.Sleep(2000);
            }
        }

        public void GrabAllMatchHistory()
        {
            _driver.Navigate().GoToUrl(this.startURL);

            var matchrows = _driver.FindElementsByClassName("css-709yn1");

            for (int i = 0; i < matchrows.Count - 1; i++)
            {
                matchrows[i].Click();

                var selectedRow = _driver.FindElementByClassName("selected");

                var matchups = selectedRow.FindElement(By.ClassName("css-ib3zj7"));
                var matchupTD = matchups.FindElements(By.TagName("td"));

                string WeekNumber = matchupTD[0].Text;
                string Date = matchupTD[1].Text;

                var matches = selectedRow.FindElements(By.ClassName("css-k8wt5j"));

                for (int j = 0; j < matches.Count - 1; j++)
                {

                    matches[j].Click();

                    var mainMatchDiv = _driver.FindElementByClassName("m-b-20 m-l-10 m-r-10");
                }
            }
        }
    }
}
