using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll.BoDi;
using System.Security.Cryptography.X509Certificates;
using MarsProject.Utilities;


namespace MarsProject.Pages
{
    public class LanguagePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By AddNewButton= By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
        private readonly By LanguageField = By.XPath("//input[@placeholder='Add Language']");
        private readonly By LanguageLevelField = By.XPath("//select[@class='ui dropdown']");
        private readonly By AddButton = By.XPath("//input[@value='Add']");
        private readonly By LanguageLastColumn = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]");
        private readonly By EditLangauge = By.XPath("//table[@class='ui fixed table']/tbody[last()]/tr[1]/td[3]/span[1]/i");
        private readonly By UpdateButton = By.XPath("//input[@value='Update']");
        private readonly By LastRowUpdatedValue = By.XPath("//table[@class='ui fixed table']/tbody[last()]/tr/td[2]");
        public readonly By DeleteRecord = By.XPath("//table[@class='ui fixed table']/tbody[last()]/tr[1]/td[3]/span[2]/i[1]");
        private readonly By AddNewButtonLocator = By.XPath("//div[@class='twelve wide column scrollTable']/div/table/thead/tr/th[3]/div");
        private readonly By ErrrorMessage =By.XPath("//div[@class='ns-box-inner']");
        private readonly By ErrorMessage1 = By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']");
        public readonly By ProfileName = By.XPath("//div[@id='account-profile-section']/div/div/div[2]/div/span");
        public IWebDriver Driver => _driver;
        private readonly Helpers helpers;

        // Initializes a new instance of the LanguagePage class with a WebDriver instance.
        // Sets up a 10-second wait ti
        public LanguagePage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
            helpers = new Helpers(driver);
        }

        public IWebElement DeleteRecordIcon()
        {
            return _driver.FindElement(DeleteRecord);
        }

        // Locates and returns the "Add New" button element on the Language page.
        public void ClickAddNewButton()
        {
            _driver.FindElement(AddNewButton).Click();
        }
        // Locates and returns the language input field element.
        public void TypeLanguageFieldValue(string languageName)
        {
            _driver.FindElement(LanguageField).SendKeys(languageName);
        }

        public void ClearLanguageFieldValue()
        {
            _driver.FindElement(LanguageField).Clear();
        }
        // Locates and returns the language level dropdown element as a SelectElement.
        public void SelectLanguageLevelDropdown(string languageLevel)
        {
           IWebElement LanguagLevelFieldElement= _driver.FindElement(LanguageLevelField);
            SelectElement LanguageLevelDropdownElementSelect = new SelectElement(LanguagLevelFieldElement);
            LanguageLevelDropdownElementSelect.SelectByText(languageLevel);
            
        }
        // Locates and returns the "Add" button element.
        public void ClickAddButton()
        {
            _driver.FindElement(AddButton).Click();
        }

        // Creates a new language record by filling in the language and level, then clicking "Add".
        public void LanguagePageRecordCreation(string language, string languageLevel)
        {
            //IWebElement AddNewButton = _driver.FindElement(By.XPath("//div[@id='account-profile-section']//div[contains(@class,'ui teal button') and text()='Add New']"));
            ClickAddNewButton();
            TypeLanguageFieldValue(language);
            SelectLanguageLevelDropdown(languageLevel);
            ClickAddButton();
        }
        // Locates and returns the language value in the last row of the language table.
        public string LanguageLastColumnText()
        {
            return _driver.FindElement(LanguageLastColumn).Text;
        }
        // Locates and returns the edit icon element for the last language record.
        public void ClickEditIcon()
        {
            _driver.FindElement(EditLangauge).Click();
        }
        // Locates and returns the language level dropdown element for updating a language record.
        public void EditLanguageLevelDropdown(string languageLevel)
        {
       
            IWebElement UpdatedLangugageLevelSelect=_driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
            SelectElement UpdateLanguageLevelDropdown= new SelectElement(UpdatedLangugageLevelSelect);
            UpdateLanguageLevelDropdown.SelectByText(languageLevel);

       }

        // Locates and returns the "Update" button element.
        public void ClickUpdateButton()
        {
            _driver.FindElement(UpdateButton).Click();
        }
        // Updates the language level of an existing language record.
        public void LanguagePageRecordUpdate(string updatedlanguagelevel)
        {

           
            ClickEditIcon();
            EditLanguageLevelDropdown(updatedlanguagelevel);
            ClickUpdateButton();
            
        }


        //  Locates and returns the updated language level value in the last row of the language table.
        public string UpdatedDatainLastRow()
        {
            
           return _driver.FindElement(LastRowUpdatedValue).Text;
        }
        // Deletes the last language record by clicking the delete icon.
        public void DeleteRecordIconClick()
        {
            _driver.FindElement(DeleteRecord).Click();
            helpers.WaitForElementDisappear(By.XPath("//div[@class='ns-box-inner']"));
       
        }

        public void verifyAddNewButtonVisible()
        {
            // FindElements returns a list, so it won't throw NoSuchElementException if not found
            var AddNewButtons = _driver.FindElements(AddNewButtonLocator);

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
        public void checkFieldsEmptyErrorMessageDisplayed()
        {
            Assert.IsTrue(_driver.FindElement(ErrrorMessage).Displayed);
        }

        public void checkErrorMessageWhenOneFieldIsEmpyty()
        {
            Assert.AreEqual("Please enter language and level", _driver.FindElement(ErrorMessage1).Text);
        }

        //public void checkCreatedRecordIsDisplayed(string language)
        //{
         //   Assert.AreEqual(language, languagePage.LanguageLastColumnText());
       // }

        public string ProfileNameText()
        {
            return _driver.FindElement(ProfileName).Text;
        }
    }
}
