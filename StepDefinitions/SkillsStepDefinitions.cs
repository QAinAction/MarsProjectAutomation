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
        this.driver= driver;
        this.baseClass= new BaseClass(driver);
            loginPage= new LoginPage(driver);
            skillPage= new SkillsPage(driver);
            helpers= new Helpers(driver);
        }
       

    }
}
