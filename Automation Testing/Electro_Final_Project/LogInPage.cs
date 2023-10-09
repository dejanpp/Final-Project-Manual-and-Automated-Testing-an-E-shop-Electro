using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro_Final_Project
{
    public class LogInPage
    {
        public IWebDriver driver;

        public LogInPage(IWebDriver createdDriver)
        {
            driver = createdDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        By userName = By.Id("username");
        By passWord = By.Id("password");
        By loginClick = By.CssSelector("button[name=\"login\"]");
        By userIsonMyAccounPage = By.XPath("//h1[text()=\"My Account\"]");



        public void EnterUserName(string user_name)
        {
            driver.FindElement(userName).SendKeys(user_name);
        }

        public void EnterPassword(string user_password)
        {
            driver.FindElement(passWord).SendKeys(user_password);
        }

        public void ClickOnLoginButton()
        {
            driver.FindElement(loginClick).Click();
        }

        public string AssertUserIsOnMyAccountPage()
        {
            IWebElement compareMyAccount = driver.FindElement(userIsonMyAccounPage);
            string userislogged = compareMyAccount.Text;
            return userislogged;
        }
    }
}
