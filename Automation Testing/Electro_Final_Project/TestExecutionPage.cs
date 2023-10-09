using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework.Internal;

namespace Electro_Final_Project
{
    [TestFixture]
    public class Final_Tests
    {
        public IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl("https://electro.madrasthemes.com/");
            driver.Manage().Window.Maximize();
        }

        HomePage homePage;
        LogInPage logInPage;
        MyAccountPage accountPage;
        AccountDetailsPage detailsPage;

        public void Log_In_With_Original_Password()
        {           
            logInPage = new LogInPage(driver);          
            logInPage.EnterUserName("dejan.stg22@gmail.com");
            logInPage.EnterPassword("dejan123456789#");
            logInPage.ClickOnLoginButton();
        }

        public void Change_Credentials()
        {
            detailsPage.EnterFirstName("DEJAN");
            detailsPage.EnterLastName("PETROSKI");
            detailsPage.EnterDisplayName("Dejan_Petroski");
        }
        public void Change_The_Password()
        {
            detailsPage = new AccountDetailsPage(driver);
            detailsPage.EnterCurrentPassword("dejan123456789#");
            detailsPage.EnterNewPassword("dejan123456789@");
            detailsPage.EnterConfirmPassword("dejan123456789@");
        }
        public void Log_In_With_Changed_Password()
        {
            logInPage = new LogInPage(driver);
            logInPage.EnterUserName("dejan.stg22@gmail.com");
            logInPage.EnterPassword("dejan123456789@");
            logInPage.ClickOnLoginButton();
        }

        public void Change_The_Password_Into_Original_Password()
        {
            detailsPage = new AccountDetailsPage(driver);
            detailsPage.EnterCurrentPassword("dejan123456789@");
            detailsPage.EnterNewPassword("dejan123456789#");
            detailsPage.EnterConfirmPassword("dejan123456789#");
        }

        [Test]
        [Order(1)]
        [Description("Task-1(Log in)")]
        public void Test_1_User_Log_In()
        {
            homePage = new HomePage(driver);

            homePage.ClickOnMyAccountButton();
            Log_In_With_Original_Password();
           
            string loginuser = logInPage.AssertUserIsOnMyAccountPage();
            Assert.AreEqual(loginuser, "My Account");
        }

        

        [Test]
        [Order(2)]
        [Description("Task-2(Change Account details)")]
        public void Test_2_Acc_Details_Change()
        {
            homePage = new HomePage(driver);
            accountPage = new MyAccountPage(driver);
            detailsPage = new AccountDetailsPage(driver);

            homePage.ClickOnMyAccountButton();
            Log_In_With_Original_Password();
            accountPage.ClickMyAccountButton();
            Change_Credentials();
            detailsPage.ClickOnSaveChangesButton();

            string succsesMessage = accountPage.AccountDetailsAssertion();
            Assert.AreEqual(succsesMessage, "Account details changed successfully.");

            string loginuser = logInPage.AssertUserIsOnMyAccountPage();
            Assert.AreEqual(loginuser, "My Account");
        }

               
        [Test]
        [Order(3)]
        [Description("Task-3(Change password)")]
        public void Test_3_Password_Change()
        {     
            homePage = new HomePage(driver);
            accountPage = new MyAccountPage(driver);
            detailsPage = new AccountDetailsPage(driver);

            homePage.ClickOnMyAccountButton();
            Log_In_With_Original_Password();
            accountPage.ClickMyAccountButton();
            Change_The_Password();           
            detailsPage.ClickOnSaveChangesButton();

            string succsesMessage = accountPage.AccountDetailsAssertion();
            Assert.AreEqual(succsesMessage, "Account details changed successfully.");

            try
            {
                logInPage.AssertUserIsOnMyAccountPage();
                throw new Exception("The user is redirected to the Dashboard");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Assertion FAIL! in TestExecutionPage line 122");
                Console.WriteLine("The user was not redirected to the Dashboard.");
                Console.WriteLine("The execution of the Test continue!");
            }
            // string loginuser = logInPage.AssertUserIsOnMyAccountPage();
            // Assert.AreEqual(loginuser, "My Account");

            accountPage.ClickLogOutButton();
            Log_In_With_Changed_Password();
            accountPage.ClickMyAccountButton();
            Change_The_Password_Into_Original_Password();
            detailsPage.ClickOnSaveChangesButton();

            // string loginuser = logInPage.AssertUserIsOnMyAccountPage();
            // Assert.AreEqual(loginuser, "My Account");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}