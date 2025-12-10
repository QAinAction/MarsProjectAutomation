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

        

    }
}
