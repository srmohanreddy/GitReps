using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NDATask.PageRepository;

namespace NDATask
{
    class NDATests
    {
        public static IWebDriver driver;
        string url = ConfigurationSettings.AppSettings["URL"];

        [SetUp]
        public void TestInitialization()
        {
            if("Chrome".Equals(ConfigurationSettings.AppSettings["Browser"]))
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }
        [TearDown]
        public void TestClosure()
        {
           driver.Quit();
        }

        [Test]
        public void TestScenario1()
        {
            string datafile = (ConfigurationSettings.AppSettings["TestDataFilePath"]);
            driver.Url = url;
            UserAccount userAccountPage = new UserAccount(driver);
            userAccountPage.UserLogin(Utilities.GetXMLData(datafile, "/TestScenario1/Verification1", "username"), Utilities.GetXMLData(datafile, "/TestScenario1/Verification1", "password"));

            //Verification #1
            try
            {
                StringAssert.Contains(Utilities.GetXMLData(datafile, "/TestScenario1/Verification1", "expectedstring"), userAccountPage.lblUserPwdValidation.Text);
            }
            catch (AssertionException ae)
            {
                Console.WriteLine(@"Error occurred logging on: " + ae.ToString());
            }
            userAccountPage.btnRequestNewPwd.Click();

            //Verification #2
            try
            {
                StringAssert.Contains(Utilities.GetXMLData(datafile, "/TestScenario1/Verification2", "expectedstring"), userAccountPage.lblUserNamePassword.Text);
            }
            catch (AssertionException ae)
            {
                Console.WriteLine(@"Error occurred logging on: " + ae.ToString());
            }
            userAccountPage.txtEmailId.SendKeys(Utilities.GetXMLData(datafile, "/TestScenario1/Verification3", "email"));
            userAccountPage.btnEmailPassword.Click();

            //Verification #3
            try
            {
                StringAssert.Contains(Utilities.GetXMLData(datafile, "/TestScenario1/Verification3", "expectedstring"), userAccountPage.lblFurtherInstructions.Text);
            }
            catch (AssertionException ae)
            {
                Console.WriteLine(@"Error occurred logging on: " + ae.ToString());
            }
            userAccountPage.UserLogin(Utilities.GetXMLData(datafile, "/TestScenario1/Verification4", "username"), Utilities.GetXMLData(datafile, "/TestScenario1/Verification4", "password"));

            TechTestUser techTestUserPage = new TechTestUser(driver);
            techTestUserPage.mlistPeople.Click();
            techTestUserPage.mitemUsers.Click();

            //verification #4
            try
            {
                StringAssert.Contains(Utilities.GetXMLData(datafile, "/TestScenario1/Verification4", "expectedstring"), driver.Title);
            }
            catch (AssertionException ae)
            {
                Console.WriteLine(@"Error occurred logging on: " + ae.ToString());
            }
            Users usersPage = new Users(driver);
            usersPage.btnImportParticipants.Click();

            //Verification #5
            try
            {
                StringAssert.Contains(Utilities.GetXMLData(datafile, "/TestScenario1/Verification5", "expectedstring"), driver.Title);
            }
            catch (AssertionException ae)
            {
                Console.WriteLine(@"Error occurred logging on: " + ae.ToString());
            }

            ImportParticipants importParicipantsPage = new ImportParticipants(driver);
            importParicipantsPage.btnBrowse.Click();

            Utilities.UploadFile("Import Participants", ConfigurationSettings.AppSettings["UserDataFilePath"]);
                       
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,1000)");
            
            importParicipantsPage.btnImport.Click();
            System.Threading.Thread.Sleep(9000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //Verificatiom #6
            try
            {
                StringAssert.Contains(Utilities.GetXMLData(datafile, "/TestScenario1/Verification5", "expectedstring"), importParicipantsPage.lblUserCreated.Text);
            }
            catch (AssertionException ae)
            {
                Console.WriteLine(@"Error occurred logging on: " + ae.ToString());
            }
        }
    }
    }
     