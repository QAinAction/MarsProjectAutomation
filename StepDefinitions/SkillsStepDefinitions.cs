using MarsProject.Pages;
using MarsProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly BaseClass baseClass;
        private readonly LoginPage loginPage;
        private readonly SkillsPage skillPage;
        private readonly Helpers helpers;
        private readonly LanguagePage languagePage;


        public SkillsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.baseClass = new BaseClass(driver);
            loginPage = new LoginPage(driver);
            skillPage = new SkillsPage(driver);
            helpers = new Helpers(driver);
            languagePage = new LanguagePage(driver);
        }
        //[Then("the user should be redirected to the Profile page with Profile name {string}")]
        //public void ThenTheUserShouldBeRedirectedToTheProfilePageWithProfileName(string ExpectedProfilename)
        //{
        //    languagePage.ThenTheTextProfileNameShouldBeDisplayed(ExpectedProfilename);
        //}

        [Then("click on Skill tab")]
        public void ThenClickOnSkillTab()
        {
            skillPage.SkillTabClick();
        }

        [When("the user clicks logs in with valid credentials {string} and {string}")]
        public void WhenTheUserClicksLogsInWithValidCredentialsAnd(string username, string password)
        {
            loginPage.Login(username, password);

        }

        [When("the user clicks on AddNew button enters {string} and {string} and clicks on Add button in the skills section")]
        public void WhenTheUserClicksOnAddNewButtonEntersAndAndClicksOnAddButtonInTheSkillsSection(string skill, string skillLevel)
        {
            skillPage.SkillsPageRecordCreation(skill, skillLevel);
        }


        [Then("the {string} skill record should be displayed in the table")]
        public void WhenTheRecordShouldBeDisplayedInTheTable(string skillslastcolumn)
        {
            Assert.AreEqual(skillslastcolumn, skillPage.SkillPageLastData());
        }
        [Then("the user clicks on the edit icon and updates the skill level{string} and clicks on update button")]
        public void ThenTheUserClicksOnTheEditIconAndUpdatesTheSkillLevelAndClicksOnUpdateButton(string updatedskilllevel)
        {
            skillPage.SkillsPageRecordUpdate(updatedskilllevel);
        }

        [Then("the <UpdatedSkillLevel> skill level should get updated successfully")]
        public void ThenTheUpdatedSkillLevelSkillLevelShouldGetUpdatedSuccessfully()
        {
            Assert.AreEqual("Intermediate", skillPage.UpdatedSkillDataOnList());

        }


        [Then("verify the Add skill validations and also when entering  {string} and {string} are working")]
        public void ThenVerifyTheAddSkillValidationsAreWorking(string skill, string skilllevel)
        {
            skillPage.SkillsPageValidationCheckwithnodata();
            Assert.IsTrue(skillPage.MessageDisplayed());
            skillPage.SkillsPageValidationCheckwithdata(skill, skilllevel);

            helpers.WaitForElement(skillPage.ErrorMessage1);
            Assert.AreEqual("This skill is already exist in your skill list.", skillPage.ReturnMessageDisplayed());

        }

        [Then("verify the Edit skill validations are working")]
        public void ThenVerifyTheEditSkillValidationsAreWorking()
        {

            skillPage.ClickSkillEditicon();
            skillPage.ClearSkillfieldValue();
            skillPage.ClickSkillUpdatebutton();
            helpers.WaitForElement(skillPage.ErrorMessage1);
            Assert.IsTrue(skillPage.MessageDisplayed());
        }

        [When("the user clicks on the cross icon against the <skill> skill record")]
        public void WhenTheUserClicksOnTheCrossIconAgainstTheSkillSkillRecord()
        {
            skillPage.ClickSkillDeleteIcon();

        }

        [Then("the {string} skill record should be deleted")]

        public void ThenTheSkillSkillRecordShouldBeDeleted(string skill)
        {
            helpers.WaitForElement(skillPage.LastRowSkill);
            
            Assert.AreNotEqual(skill, skillPage.LastRowSkillFieldValue());
        }



    }
}
