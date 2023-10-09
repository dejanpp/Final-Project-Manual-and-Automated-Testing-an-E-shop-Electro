using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro_Final_Project
{
    public class MyAccountPage
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        public MyAccountPage(IWebDriver createdDriver)
        {
            driver = createdDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        By clickAccountDetails = By.XPath("//a[text()=\"Account details\"]");
        By saveChangesMessage = By.CssSelector("div.woocommerce-message");
        By logOutButton = By.XPath("//a[text()=\"Logout\"]");

        public void ClickMyAccountButton()
        {
            IList<IWebElement> myAccButton = driver.FindElements(clickAccountDetails);
            myAccButton[myAccButton.Count - 1].Click();
        }

        public string AccountDetailsAssertion()
        {
            IWebElement changesMessage = driver.FindElement(saveChangesMessage);
            //wait.Until(ExpectedConditions.ElementIsVisible(saveChangesMessage));
            string message = changesMessage.Text;
            return message;
        }

        public void ClickLogOutButton()
        {
            IList<IWebElement> logoutButton = driver.FindElements(logOutButton);
            logoutButton[logoutButton.Count - 1].Click();
        }

    }
}
