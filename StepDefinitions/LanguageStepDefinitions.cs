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
        public void ThenTheTextProfileNameShouldBeDisplayed(string ExpectedProfilename)
        {
            helpers.WaitForElement(languagePage.ProfileName);
           string profilenametext = languagePage.ProfileNameText();
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
            helpers.WaitForElementDisappear(By.XPath("//div[@class='ns-box-inner']"));
        }

        [Then("the {string} record should be displayed in the table")]
        public void ThenTheRecordShouldBeDisplayedInTheTable(string language)
        {
            helpers.Wait(6000);
            Assert.AreEqual(language, languagePage.LanguageLastColumnText());

        }

        [When("the user clicks on edit icon and updates the field with {string}")]
        public void WhenTheUserClicksOnEditIconAndUpdatesTheLanguageFieldWithUpdatedLanguageLevel(string updatedlanguagelevel)
        {
            languagePage.LanguagePageRecordUpdate(updatedlanguagelevel);
        }

        [Then("the {string} of the record should get updated successfully")]
        public void ThenTheRecordShouldGetUpdatedSuccessfully(string updatedlanguagelevel)
        {
         Assert.AreEqual(updatedlanguagelevel, languagePage.UpdatedDatainLastRow());
        }

        [Then("verify adding language {string} validations are working")]
        public void ThenVerifyAddingLanguageValidationsAreWorking(string language)
        {
            // succuess toast box xpath : //div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']
            // error toast box xpath : //div[@class='ns-box-inner']
            //Verify all validations here : mandatory language field, mandatory language level,etc
            languagePage.ClickAddNewButton();
            languagePage.ClickAddButton();
            languagePage.checkFieldsEmptyErrorMessageDisplayed();
            languagePage.TypeLanguageFieldValue(language);
            languagePage.ClickAddButton();
            languagePage.checkErrorMessageWhenOneFieldIsEmpyty();
        }

        [Then("verify editing language {string} and {string} validations are working")]
        public void ThenVerifyEditingLanguageAndLanguageAndValidationsAreWorking(string language, string languageLevel)
        {
            languagePage.ClickEditIcon();
            languagePage.ClearLanguageFieldValue();
            helpers.WaitForElement(By.XPath("//input[@value='Update']"));
            languagePage.ClickUpdateButton();
            helpers.WaitForElement(By.XPath("//div[@class='ns-box-inner']"));
            IWebElement ErrorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Assert.IsTrue(ErrorMessage.Displayed);
            languagePage.TypeLanguageFieldValue(language);
            languagePage.SelectLanguageLevelDropdown(languageLevel);
            languagePage.ClickUpdateButton();
            IWebElement ErrorMessage1 = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Assert.AreEqual("This language is already added to your language list.", ErrorMessage1.Text);
            helpers.WaitForElementDisappear(By.XPath("//div[@class='ns-box-inner']"));
        }

        [When("the user clicks on Add New button and creates the last language record with {string} and {string} after that the button is disabled")]
        public void WhenTheUserClicksOnAddNewButtonAndCreatesTheLastLanguageRecordWithAndAfterThatTheButtonIsDisabled(string language, string languageLevel)
        {
            languagePage.ClickAddNewButton();
            languagePage.TypeLanguageFieldValue(language);
            languagePage.SelectLanguageLevelDropdown(languageLevel);
            languagePage.ClickAddButton();
            languagePage.verifyAddNewButtonVisible();
        }



        //[When("the user clicks on Add New button and creates the last language record after that the button is disabled")]
        //public void WhenTheUserClicksOnAddNewButtonAndCreatesLastLanguageRecords(string language, string languagelevel)
        //{
        // languagePage.ClickAddNewButton();
        //languagePage.TypeLanguageFieldValue(language);
        //languagePage.ClickAddNewButton();
        //languagePage.TypeLanguageFieldValue(language);
        //languagePage.SelectLanguageLevelDropdown(languagelevel);
        //    languagePage.ClickAddButton();
        //    languagePage.verifyAddNewButtonVisible();
        //}

        [When("the user clicks on the cross icon against the {string} record")]
        public void WhenTheUserClicksOnTheCrossIconAgainstTheRecord(string english)
        {
            languagePage.DeleteRecordIconClick();
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
