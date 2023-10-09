using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Electro_Final_Project
{
    public class AccountDetailsPage
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        public AccountDetailsPage(IWebDriver createdDriver)
        {
            driver = createdDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }


        
        By clickOnFirstName = By.Id("account_first_name");
        By clickOnLastName = By.Id("account_last_name");
        By clickOnDisplayName = By.Id("account_display_name");
        By clickOnSaveChanges = By.XPath("//button[text()=\"Save changes\"]");

        By currentPassword = By.Id("password_current");
        By newPassword = By.Id("password_1");
        By confirmPassword = By.Id("password_2");



        Random random = new Random();
        public void EnterFirstName(string first_name)
        {
            int randomInt = random.Next(100);
            IWebElement firstName = driver.FindElement(clickOnFirstName);
            firstName.Clear();
            firstName.SendKeys(first_name + randomInt);
        }

        public void EnterLastName(string last_name)
        {
            int randomInt = random.Next(100);
            IWebElement lastName = driver.FindElement(clickOnLastName);
            lastName.Clear();
            lastName.SendKeys(last_name + randomInt);
        }

        public void EnterDisplayName(string display_name)
        {
            int randomInt = random.Next(100);
            IWebElement displayName = driver.FindElement(clickOnDisplayName);
            displayName.Clear();
            displayName.SendKeys(display_name + randomInt);
        }

        public void ClickOnSaveChangesButton()
        {
            IWebElement saveChanges = driver.FindElement(clickOnSaveChanges);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", saveChanges);
           // wait.Until(ExpectedConditions.ElementIsVisible(clickOnSaveChanges)).Click();
        }

        public void EnterCurrentPassword(string current_password)
        {
            driver.FindElement(currentPassword).SendKeys(current_password);
        }

        public void EnterNewPassword(string new_password)
        {
            driver.FindElement(newPassword).SendKeys(new_password);
        }

        public void EnterConfirmPassword(string confirm_password)
        {
            driver.FindElement(confirmPassword).SendKeys(confirm_password);
        }


    }
}
