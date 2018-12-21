using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NDATask.PageRepository
{
    class PageObjects
    {
        public IWebDriver driver;
        //to - do to intitialize all pages here
    }

    class UserAccount
    {
        private IWebDriver driver;

        public UserAccount(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region properties
        [FindsBy(How = How.Name, Using = "op")]
        public IWebElement btnLogin { get; set; }
        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement txtUserName { get; set; }
        [FindsBy(How = How.Name, Using = "pass")]
        public IWebElement txtPassword { get; set; }
        [FindsBy(How = How.XPath, Using = ".//div[@class='alert alert-block alert-danger']")]
        public IWebElement lblUserPwdValidation { get; set; }
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(),'Request new password')]")]
        public IWebElement btnRequestNewPwd { get; set; }
        [FindsBy(How = How.XPath, Using = ".//label[@for='edit-name']")]
        public IWebElement lblUserNamePassword { get; set; }
        [FindsBy(How = How.XPath, Using = ".//input[@id='edit-name']")]
        public IWebElement txtEmailId { get; set; }
        [FindsBy(How = How.XPath, Using = ".//button[@id='edit-submit']")]
        public IWebElement btnEmailPassword { get; set; }
        [FindsBy(How = How.XPath, Using = ".//div[@class='alert alert-block alert-success']")]
        public IWebElement lblFurtherInstructions { get; set; }
        #endregion
        #region Methods
        public void UserLogin(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);
            btnLogin.Click();
        }
        #endregion
    }

    class TechTestUser
    {
        private IWebDriver driver;

        public TechTestUser(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region properties
        [FindsBy(How = How.XPath, Using = ".//li[@class='first expanded dropdown']")]
        public IWebElement mlistPeople { get; set; }
        [FindsBy(How = How.XPath, Using = ".//a[@href='/home/403160/admin/people']")]
        public IWebElement mitemUsers { get; set; }
        #endregion
    }

    class Users
    {
        private IWebDriver driver;

        public Users(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region properties
        [FindsBy(How = How.XPath, Using = ".//i[@class='fa fa-upload']")]
        public IWebElement btnImportParticipants { get; set; }
        #endregion
    }

    class ImportParticipants
    {
        private IWebDriver driver;

        public ImportParticipants(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region properties
        [FindsBy(How = How.XPath, Using = ".//input[@id='edit-feeds-feedsfilefetcher-upload']")]
        public IWebElement btnBrowse { get; set; }
        [FindsBy(How = How.XPath, Using = ".//button[@id='edit-submit']")]
        public IWebElement btnImport { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']/div/div/section/div[2]")]
        public IWebElement lblUserCreated { get; set; }
        #endregion
        ////*[@id="body-container"]/div/div/section/div[2]
    }
}
