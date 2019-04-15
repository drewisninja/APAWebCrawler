using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebCrawler.BusinessLogic;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var driver = new ChromeDriver("C:/Users/ayira/Desktop/APA"))
            {
                LoginPage LP = new LoginPage(driver, "https://league.poolplayers.com/login");
                LP.SignIn();

                PlayerStatsProcessor processor = new PlayerStatsProcessor(driver, "https://league.poolplayers.com/oc/divisions/281050/standings");
                processor.ProcessPlayerHighLevelStats();

                //PlayerStatsProcessor processor = new PlayerStatsProcessor(driver, "https://league.poolplayers.com/oc/divisions/281050/schedule/");
                //processor.GrabAllMatchHistory();

                var pause = "";

                driver.Close();
                driver.Quit();
            }
        }
    }
}
