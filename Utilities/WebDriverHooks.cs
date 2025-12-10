using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (driver != null)
            {
                //driver.Quit();
                //driver.Dispose();
            }
        }
    }
}

