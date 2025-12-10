using MarsProject.Utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Pages
{
    public class SkillsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait wait;
        private readonly Helpers helpers;
        public IWebDriver Driver => _driver;


        // Initializes a new instance of the SkillsPage class with a WebDriver instance.
        public SkillsPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
            helpers = new Helpers(_driver);
        }
        // Locates and returns the Skill tab element.
        public IWebElement Skilltabclick(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[2]"));

        }
        // Locates and returns the "Add New" button element on the Skills page.
        public IWebElement SkillAddNewbutton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/thead/tr/th[3]/div"));
        }
        // Locates and returns the skill input field element.
        public IWebElement Skillfieldvalue(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        }
        // Locates and returns the skill level dropdown element as a SelectElement.
        public SelectElement SkillLevelvalue(IWebDriver driver)
        {
            IWebElement SkillLevelvalue = driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
            SelectElement SkillLevelvalueSelect = new SelectElement(SkillLevelvalue);
            return SkillLevelvalueSelect;
        }
        // Locates and returns the "Add" button element.
        public IWebElement SkillAddbutton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//input[@value='Add']"));
        }
        // Creates a new skill record by filling in the skill and level, then clicking "Add".
        public void SkillsPageRecordCreation(string skill, string skilllevel)
        {

            Skilltabclick(_driver).Click();
            SkillAddNewbutton(_driver).Click();
            Skillfieldvalue(_driver).SendKeys(skill);
            SkillLevelvalue(_driver).SelectByText(skilllevel);
            SkillAddbutton(_driver).Click();
        }
        // Locates and returns the skill value in the last row of the skills table.
        public IWebElement SkillLastData(IWebDriver driver)
        {
            helpers.WaitForElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            return driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

        }
        // Locates and returns the edit icon element for the last skill record.
        public IWebElement SkillEditicon(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]"));
        }
        // Locates and returns the skill level dropdown element for updating as a SelectElement.
        public SelectElement SkillLevelUpdate(IWebDriver driver)
        {
            IWebElement SkillLevelUpdate = driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
            SelectElement SkillLevelUpdateSelect = new SelectElement(SkillLevelUpdate);
            return SkillLevelUpdateSelect;

        }
        // Locates and returns the "Update" button element.
        public IWebElement SkillUpdatebutton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//input[@value='Update']"));
        }
        // Updates an existing skill record by changing the skill level and clicking "Update".
        public void SkillsPageRecordUpdate(string updatedskilllevel)
        {
            Skilltabclick(_driver).Click();
            SkillEditicon(_driver).Click();
            SkillLevelUpdate(_driver).SelectByText(updatedskilllevel);
            SkillUpdatebutton(_driver).Click();
        }
        // Locates and returns the updated skill level value in the last row of the skills table.
        public IWebElement SkillDataUpdated(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        }
        // Validates adding a skill without data.
        public void SkillsPageValidationCheckwithnodata()
        {

            SkillAddNewbutton(_driver).Click();
            SkillAddbutton(_driver).Click();
        }
        // Validates adding a skill with provided data.
        public void SkillsPageValidationCheckwithdata(string skill, string skilllevel)
        {
            Skillfieldvalue(_driver).SendKeys(skill);
            SkillLevelvalue(_driver).SelectByText(skilllevel);
            SkillAddbutton(_driver).Click();


        }
        // Locates and returns the delete icon element for the last skill record.
        public IWebElement SkillDeleteIcon(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
        }
        // Deletes the last skill record by clicking the delete icon.
        public void SkillsPageDeleteRecord()
        {
            SkillDeleteIcon(_driver).Click();
        }
    }
}
