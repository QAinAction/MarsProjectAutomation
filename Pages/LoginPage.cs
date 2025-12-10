using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll.BoDi;

namespace MarsProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public IWebDriver Driver => _driver;

        public LoginPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
        }

        
        
    }
}
