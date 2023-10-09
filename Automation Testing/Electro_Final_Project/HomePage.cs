using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro_Final_Project
{
    public class HomePage
    {
        public IWebDriver driver;

        public HomePage(IWebDriver createdDriver)
        {
            driver = createdDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        By myAccountClick = By.CssSelector("a[title=\"My Account\"]");



        public void ClickOnMyAccountButton()
        {
            driver.FindElement(myAccountClick).Click();
        }
    }
}
