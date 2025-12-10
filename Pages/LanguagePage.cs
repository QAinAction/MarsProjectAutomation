using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll.BoDi;


namespace MarsProject.Pages
{
    public class LanguagePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

        // Initializes a new instance of the LanguagePage class with a WebDriver instance.
        // Sets up a 10-second wait ti
        public LanguagePage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }

        // Locates and returns the "Add New" button element on the Language page.
        public IWebElement AddNewButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        }
        // Locates and returns the language input field element.
        public IWebElement LanguageField(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        }
        // Locates and returns the language level dropdown element as a SelectElement.
        public SelectElement LanguageLevelDropdown(IWebDriver driver)
        {
            IWebElement LanguageLevelDropdownElement = _driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
            SelectElement LanguageLevelDropdownElementSelect = new SelectElement(LanguageLevelDropdownElement);
            return LanguageLevelDropdownElementSelect;
        }
        // Locates and returns the "Add" button element.
        public IWebElement AddButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//input[@value='Add']"));
        }

        // Creates a new language record by filling in the language and level, then clicking "Add".
        public void LanguagePageRecordCreation(string language, string languageLevel)
        {
            //IWebElement AddNewButton = _driver.FindElement(By.XPath("//div[@id='account-profile-section']//div[contains(@class,'ui teal button') and text()='Add New']"));
            AddNewButton(_driver).Click();
            LanguageField(_driver).SendKeys(language);
            LanguageLevelDropdown(_driver).SelectByText(languageLevel);
            AddButton(_driver).Click();
        }
        // Locates and returns the language value in the last row of the language table.
        public IWebElement LanguageLastColumn(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[last()]/tr/td[1]"));
        }
        // Locates and returns the edit icon element for the last language record.
        public IWebElement EditIcon(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[last()]/tr[1]/td[3]/span[1]/i"));
        }
        // Locates and returns the language level dropdown element for updating a language record.
        public IWebElement UpdatedLanguageLevelDropdown(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
        }
        // Locates and returns the "Update" button element.
        public IWebElement UpdateButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//input[@value='Update']"));
        }
        // Updates the language level of an existing language record.
        public void LanguagePageRecordUpdate(string updatedlanguagelevel)
        {

            EditIcon(_driver).Click();
            UpdatedLanguageLevelDropdown(_driver);
            SelectElement select = new SelectElement(UpdatedLanguageLevelDropdown(_driver));
            select.SelectByText(updatedlanguagelevel);
            UpdateButton(_driver).Click();
        }
        //  Locates and returns the updated language level value in the last row of the language table.
        public IWebElement UpdatedDatainLastRow(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[last()]/tr/td[2]"));
        }
        // Deletes the last language record by clicking the delete icon.
        public void DeleteRecord()
        {
            IWebElement CrossIcon = _driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[last()]/tr[1]/td[3]/span[2]/i[1]"));
            CrossIcon.Click();
        }
    }
}
