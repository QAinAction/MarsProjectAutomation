using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Utilities
{
    public class Helpers
    {
        private readonly WebDriverWait wait;
        private readonly IWebDriver _driver;
        public IWebDriver Driver => _driver;
        public Helpers(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }
        public void WaitForElement(By element)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

      

    }
}
