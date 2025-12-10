using MarsProject.Pages;
using MarsProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;
using System.Net.Mail;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly BaseClass baseClass;
        private readonly LoginPage loginPage;
        private readonly LanguagePage languagePage;
        private readonly Helpers helpers;



        public LanguageStepDefinitions(IWebDriver driver)
        {
            // Assign 'driver' to private field or use it to initialize a page object
            this.driver = driver;

            // Initialize Selenium page object
            this.baseClass = new BaseClass(driver);

            loginPage = new LoginPage(driver);
            languagePage = new LanguagePage(driver);
            helpers = new Helpers(driver);
        }

        [Given("the Mars Project url is opened")]
        public void GivenTheMarsProjectUrlIsOpened()
        {
            driver.Navigate().GoToUrl("http://localhost:5003/Home");
        }

        [When("the user logs in with valid credentials {string} and {string}")]
        public void WhenTheUserLogsInWithValidCredentialsAnd(string emailAddress, string password)
        {
            loginPage.Login(emailAddress, password);
        }

        [Then("the user should be redirected to the Profile page")]
        public void ThenTheUserShouldBeRedirectedToTheProfilePage()
        {
            Thread.Sleep(3000);
            string currentUrl = driver.Url;
            Assert.AreEqual("http://localhost:5003/Account/Profile", currentUrl);
        }

        [Then("the text {string} should be displayed.")]
        public void ThenTheTextProfileNameShouldBeDisplayed_(string ExpectedProfilename)
        {
            IWebElement ProfileName = driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/div/div[2]/div/span"));
            string profilenametext = ProfileName.Text;
            Assert.AreEqual(profilenametext, ExpectedProfilename);
        }
        [When("the user logs in with invalid credentials {string} and {string}")]
        public void WhenTheUserLogsInWithInvalidCredentialsAnd(string username, string password)
        {
            loginPage.Invalidlogin(username, password);

        }


        [Then("the user should not be redirected to the Profile Page")]
        public void ThenTheUserShouldNotBeRedirectedToTheProfilePage()
        {
            string currentUrl = driver.Url;
            Assert.AreEqual("http://localhost:5003/Home", currentUrl);
        }
        //User clicks on Add New Button and enters language and language level and clicks on Add button
        [Then("the user clicks on AddNew button enters {string} and {string} and clicks on Add button")]
        public void ThenTheUserClicksOnAddNewButtonEntersAndAndClicksOnAddButton(string language, string languageLevel)
        {
            languagePage.LanguagePageRecordCreation(language, languageLevel);
        }

        [Then("the {string} record should be displayed in the table")]
        public void ThenTheRecordShouldBeDisplayedInTheTable(string language)
        {
            languagePage.LanguageLastColumn(driver);
            Assert.AreEqual(language, languagePage.LanguageLastColumn(driver).Text);

        }

        [When("the user clicks on edit icon and updates the field with {string}")]
        public void WhenTheUserClicksOnEditIconAndUpdatesTheLanguageFieldWithUpdatedLanguageLevel(string updatedlanguagelevel)
        {
            languagePage.LanguagePageRecordUpdate(updatedlanguagelevel);
        }

        [Then("the {string} of the record should get updated successfully")]
        public void ThenTheRecordShouldGetUpdatedSuccessfully(string updatedlanguagelevel)
        {
            languagePage.UpdatedDatainLastRow(driver);
            Assert.AreEqual(updatedlanguagelevel, languagePage.UpdatedDatainLastRow(driver).Text);
        }

        [Then("verify the Add language validations are working")]
        public void ThenVerifyTheValidationsAreWorking()
        {
            // succuess toast box xpath : //div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']
            // error toast box xpath : //div[@class='ns-box-inner']
            //Verify all validations here : mandatory language field, mandatory language level,etc
            languagePage.AddNewButton(driver).Click();
            languagePage.AddButton(driver).Click();
            IWebElement ErrorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Assert.IsTrue(ErrorMessage.Displayed);
            languagePage.LanguageField(driver).SendKeys("English");
            languagePage.AddButton(driver).Click();
            IWebElement ErrorMessage1 = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            Assert.AreEqual("Please enter language and level", ErrorMessage1.Text);
        }


        //validating the edit language records are working properly
        [Then("verify the Edit language validations are working")]
        public void ThenVerifyTheEditLanguageValidationsAreWorking()
        {
            languagePage.EditIcon(driver).Click();
            languagePage.LanguageField(driver).Clear();
            helpers.WaitForElement(By.XPath("//input[@value='Update']"));
            languagePage.UpdateButton(driver).Click();
            IWebElement ErrorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Assert.IsTrue(ErrorMessage.Displayed);
            languagePage.LanguageField(driver).SendKeys("English");
            languagePage.LanguageLevelDropdown(driver).SelectByText("Native/Bilingual");
            languagePage.UpdateButton(driver).Click();
            IWebElement ErrorMessage1 = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Assert.AreEqual("This language is already added to your language list.", ErrorMessage1.Text);



        }

        [When("the user clicks on Add New button and creates the last language record after that the button is disabled")]
        public void WhenTheUserClicksOnAddNewButtonAndCreatesLastLanguageRecords()
        {
            languagePage.AddNewButton(driver).Click();
            languagePage.LanguageField(driver).SendKeys("French");
            languagePage.LanguageLevelDropdown(driver).SelectByText("Basic");
            languagePage.AddButton(driver).Click();
            By AddNewButtonlocator = By.XPath("//div[@class='twelve wide column scrollTable']/div/table/thead/tr/th[3]/div"); // Replace with your element's locator

            // FindElements returns a list, so it won't throw NoSuchElementException if not found
            var AddNewButtons = driver.FindElements(AddNewButtonlocator);

            if (AddNewButtons.Count == 0)
            {
                // Element is not present in the DOM, so it's not displayed
                Assert.IsTrue(true, "Add New Button is not present in the Page."); // Or simply pass if this is the desired outcome
            }
            else
            {
                // Element is present, now check if it's displayed
                IWebElement AddNewBtn = AddNewButtons[0];
                Assert.IsFalse(AddNewBtn.Displayed, "Add New Button is unexpectedly displayed.");
            }
        }

        [When("the user clicks on the cross icon against the {string} record")]
        public void WhenTheUserClicksOnTheCrossIconAgainstTheRecord(string english)
        {
            languagePage.DeleteRecord();
        }

        [Then("the {string} record should be deleted")]
        public void ThenTheRecordShouldBeDeleted(string language)
        {
            helpers.WaitForElement(By.XPath("//table[@class='ui fixed table']/tbody[last()]/tr/td"));
            IWebElement DatainLastRow = driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[last()]/tr/td"));
            Assert.AreNotEqual(language, DatainLastRow.Text);
        }



    }
}
