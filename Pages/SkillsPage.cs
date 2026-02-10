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
        private readonly By SkillTab = By.XPath("//div[@class='ui top attached tabular menu']/a[2]");
        private readonly By SkillAddNewButton =By.XPath("//div[@data-tab='second']/div/div[2]/div/table/thead/tr/th[3]/div");
        private readonly By SkillField = By.XPath("//input[@placeholder='Add Skill']");
        private readonly By SkillLevelDropdown = By.XPath("//select[@class='ui fluid dropdown']");
        private readonly By SkillLevelAddBtn = By.XPath("//input[@value='Add']");
        private readonly By SkillLastData =By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[1]");
        private readonly By SkillEditIcon = By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]");
        private readonly By SkillLevelUpdate = By.XPath("//select[@class='ui fluid dropdown']");
        private readonly By SkillLevelUpdateBtn = By.XPath("//input[@value='Update']");
        private readonly By SkillLevelDataUpdtd = By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[2]");
        private readonly By SkillLevelDeleteIcon = By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]");
        public readonly By ErrorMessage1 = By.XPath("//div[@class='ns-box-inner']");
        public readonly By LastRowSkill = By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[1]");
        public IWebDriver Driver => _driver;


        // Initializes a new instance of the SkillsPage class with a WebDriver instance.
        public SkillsPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
            helpers = new Helpers(_driver);
        }
        // Locates and returns the Skill tab element.
        public void SkillTabClick()
        {
             _driver.FindElement(SkillTab).Click();


        }
        // Locates and returns the "Add New" button element on the Skills page.
        public void SkillAddNewButtonClick()
        {
            _driver.FindElement(SkillAddNewButton).Click();
        }
        // Locates and returns the skill input field element.
        public void TypeSkillfieldvalue(string skill)
        {
            _driver.FindElement(SkillField).SendKeys(skill);
        }

        public void ClearSkillfieldValue()
        {
            _driver.FindElement(SkillField).Clear();
        }
        // Locates and returns the skill level dropdown element as a SelectElement.
        public void SelectSkillLevelvalue(string SkillLevel)
        {
            IWebElement SkillLevelValue = _driver.FindElement(SkillLevelDropdown);
            SelectElement SkillLevelvalueSelect = new SelectElement(SkillLevelValue);
            SkillLevelvalueSelect.SelectByText(SkillLevel);
        }
        // Locates and returns the "Add" button element.
        public void ClickSkillAddbutton()
        {
           _driver.FindElement(SkillLevelAddBtn).Click();
        }
        // Creates a new skill record by filling in the skill and level, then clicking "Add".
        public void SkillsPageRecordCreation(string skill, string skillevel)
        {
            SkillTabClick();
            SkillAddNewButtonClick();
            TypeSkillfieldvalue(skill);
            SelectSkillLevelvalue(skillevel);
            ClickSkillAddbutton();
        }
        // Locates and returns the skill value in the last row of the skills table.
        public string SkillPageLastData()
        {
            helpers.WaitForElement(SkillLastData);

            return _driver.FindElement(SkillLastData).Text;

        }
        // Locates and returns the edit icon element for the last skill record.
        public void ClickSkillEditicon()
        {
            _driver.FindElement(SkillEditIcon).Click();
        }
        // Locates and returns the skill level dropdown element for updating as a SelectElement.
        public void EditSkillLevel(string skilllevel)
        {
            IWebElement SkillLevelupdate = _driver.FindElement(SkillLevelUpdate);
            SelectElement SkillLevelUpdateSelect = new SelectElement(SkillLevelupdate);
            SkillLevelUpdateSelect.SelectByText(skilllevel);

        }
        // Locates and returns the "Update" button element.
        public void ClickSkillUpdatebutton()
        {
            _driver.FindElement(SkillLevelUpdateBtn).Click();
        }
        // Updates an existing skill record by changing the skill level and clicking "Update".
        public void SkillsPageRecordUpdate(string updatedskilllevel)
        {
            SkillTabClick();
            ClickSkillEditicon();
            EditSkillLevel(updatedskilllevel);
            ClickSkillUpdatebutton();
           
        }
        // Locates and returns the updated skill level value in the last row of the skills table.
        public string UpdatedSkillDataOnList()
        {
           return _driver.FindElement(SkillLevelDataUpdtd).Text;
        }
        // Validates adding a skill without data.
        public void SkillsPageValidationCheckwithnodata()
        {
            SkillAddNewButtonClick();
            ClickSkillAddbutton();
           
        }
        // Validates adding a skill with provided data.
        public void SkillsPageValidationCheckwithdata(string skill, string skilllevel)
        {

            TypeSkillfieldvalue(skill);
            SelectSkillLevelvalue(skilllevel);
            ClickSkillAddbutton();
            


        }
        // Locates and returns the delete icon element for the last skill record.
        public IWebElement SkillDeleteIcon()
        {
            return _driver.FindElement(SkillLevelDeleteIcon);
        }
        public void ClickSkillDeleteIcon()
        {
            _driver.FindElement(SkillLevelDeleteIcon).Click();
        }
        // Deletes the last skill record by clicking the delete icon.
        public Boolean MessageDisplayed()
        {
            return _driver.FindElement(ErrorMessage1).Displayed;
        }
        public string ReturnMessageDisplayed()
        { 
            return _driver.FindElement(ErrorMessage1).Text;
        }
        public string LastRowSkillFieldValue()
        {
            return _driver.FindElement(LastRowSkill).Text;
        }
    }
}
