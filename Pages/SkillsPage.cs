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
        
    }
}
