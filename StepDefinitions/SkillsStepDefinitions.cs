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

        public SkillsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.baseClass = new BaseClass(driver);
            loginPage = new LoginPage(driver);
            skillPage = new SkillsPage(driver);
            helpers = new Helpers(driver);
        }
        [Then("the user should be redirected to the Profile page with Profile name {string}")]
        public void ThenTheUserShouldBeRedirectedToTheProfilePageWithProfileName(string ExpectedProfilename)
        {
            helpers.WaitForElement(By.XPath("//div[@id='account-profile-section']/div/div/div[2]/div/span"));
            IWebElement ProfileName = driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/div/div[2]/div/span"));
            string profilenametext = ProfileName.Text;
            Assert.AreEqual(profilenametext, ExpectedProfilename);
        }

        [Then("click on Skill tab")]
        public void ThenClickOnSkillTab()
        {
            skillPage.Skilltabclick(driver).Click();
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
            Assert.AreEqual(skillslastcolumn, skillPage.SkillLastData(driver).Text);
        }
        [Then("the user clicks on the edit icon and updates the skill level{string} and clicks on update button")]
        public void ThenTheUserClicksOnTheEditIconAndUpdatesTheSkillLevelAndClicksOnUpdateButton(string updatedskilllevel)
        {
            skillPage.SkillsPageRecordUpdate(updatedskilllevel);
        }

        [Then("the <UpdatedSkillLevel> skill level should get updated successfully")]
        public void ThenTheUpdatedSkillLevelSkillLevelShouldGetUpdatedSuccessfully()
        {
            Assert.AreEqual("Intermediate", skillPage.SkillDataUpdated(driver).Text);

        }


        [Then("verify the Add skill validations and also when entering  {string} and {string} are working")]
        public void ThenVerifyTheAddSkillValidationsAreWorking(string skill, string skilllevel)
        {
            skillPage.SkillsPageValidationCheckwithnodata();
            IWebElement ErrorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Assert.IsTrue(ErrorMessage.Displayed);
            skillPage.SkillsPageValidationCheckwithdata(skill, skilllevel);
            helpers.WaitForElement(By.XPath("//div[@class='ns-box-inner']"));
            IWebElement ErrorMessage1 = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Assert.AreEqual("This skill is already exist in your skill list.", ErrorMessage1.Text);

        }

        [Then("verify the Edit skill validations are working")]
        public void ThenVerifyTheEditSkillValidationsAreWorking()
        {

            skillPage.SkillEditicon(driver).Click();
            skillPage.Skillfieldvalue(driver).Clear();
            skillPage.SkillUpdatebutton(driver).Click();
            helpers.WaitForElement(By.XPath("//div[@class='ns-box-inner']"));
            IWebElement ErrorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Assert.IsTrue(ErrorMessage.Displayed);
        }

        [When("the user clicks on the cross icon against the <skill> skill record")]
        public void WhenTheUserClicksOnTheCrossIconAgainstTheSkillSkillRecord()
        {
            skillPage.SkillsPageDeleteRecord();

        }

        [Then("the {string} skill record should be deleted")]

        public void ThenTheSkillSkillRecordShouldBeDeleted(string skill)
        {
            helpers.WaitForElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement DatainLastRow = driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Thread.Sleep(3000);
            Assert.AreNotEqual(skill, DatainLastRow.Text);
        }



    }
}
