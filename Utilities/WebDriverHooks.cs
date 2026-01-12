using MarsProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V140.DOM;
using Reqnroll;
using Reqnroll.BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Utilities
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer _objectContainer;

        public WebDriverHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            // Set up the WebDriver instance, for example, using ChromeDriver
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            var driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            // Make the 'driver' instance available for all step definitions
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            
            var driver = _objectContainer.Resolve<IWebDriver>();
            removeAllLanguages(driver);
            removeAllSkills(driver);
            if (driver != null)
            {
                //driver.Quit();
                //driver.Dispose();
            }
        }

        public void removeAllLanguages(IWebDriver driver)
        {
            //LoginPage loginPage = new LoginPage(driver);
            LanguagePage languagePage = new LanguagePage(driver);
            //loginPage.Login("lija2512@gmail.com", "123456");
            driver.Navigate().GoToUrl("http://localhost:5003/Account/Profile");
            try
            {
                while (languagePage.DeleteRecordIcon().Displayed)
                {
                    languagePage.DeleteRecordIconClick();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            

        }
        public void removeAllSkills(IWebDriver driver)
        {
            SkillsPage skillPage= new SkillsPage(driver);
            driver.Navigate().GoToUrl("http://localhost:5003/Account/Profile");
            skillPage.SkillTabClick();
            try
            {
                while (skillPage.SkillDeleteIcon().Displayed)
                {
                    skillPage.ClickSkillDeleteIcon();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

