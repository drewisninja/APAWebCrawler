using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebCrawler.BusinessLogic
{
    public class LoginPage
    {
        ChromeDriver _driver;
        string startURL;

        public LoginPage(ChromeDriver driver, string url)
        {
            this._driver = driver;
            this.startURL = url;
        }

        public void SignIn()
        {
            //Login Page
            _driver.Navigate().GoToUrl(this.startURL);

            for (var i = 0; i < 10; i++)
            {
                if (_driver.FindElement(By.Id("username")) != null) break;
                Thread.Sleep(1000);
            }

            var userName = _driver.FindElementById("username");
            var userPassword = _driver.FindElementById("password");
            var loginButton = _driver.FindElementByClassName("btn");

            userName.SendKeys("");
            userPassword.SendKeys("");

            loginButton.Click();

            System.Threading.Thread.Sleep(1000);

            //var dontaskmeagaincheck = driver.FindElementByPartialLinkText("Don't ask me again");
            var notifyMe = _driver.FindElementByClassName("css-1nnnf3h");

            //dontaskmeagaincheck.Click();
            notifyMe.Click();

            //Now we're on the dashboard
            _driver.Manage().Window.Maximize();
        }
    }
}
