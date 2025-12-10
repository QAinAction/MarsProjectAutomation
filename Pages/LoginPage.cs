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

        public void Login(string username, string password)
        {
            IWebElement SignInlink = _driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            SignInlink.Click();

            IWebElement EmailAddressTextBox = _driver.FindElement(By.XPath("//input[@name='email']"));
            EmailAddressTextBox.SendKeys(username);

            IWebElement PasswordTextBox = _driver.FindElement(By.XPath("//input[@name='password']"));
            PasswordTextBox.SendKeys(password);

            IWebElement LoginButton = _driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            LoginButton.Click();
        }

        public void Invalidlogin(string username, string password)
        {
            IWebElement SignInlink = _driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            SignInlink.Click();
            IWebElement EmailAddressTextBox = _driver.FindElement(By.XPath("//input[@name='email']"));
            EmailAddressTextBox.SendKeys(username);
            IWebElement PasswordTextBox = _driver.FindElement(By.XPath("//input[@name='password']"));
            PasswordTextBox.SendKeys(password);
            IWebElement LoginButton = _driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            LoginButton.Click();
        }

        public void Skillpagelogin(string username, string password)
        {
            IWebElement SignInlink = _driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            SignInlink.Click();
            IWebElement EmailAddressTextBox = _driver.FindElement(By.XPath("//input[@name='email']"));
            EmailAddressTextBox.SendKeys(username);
            IWebElement PasswordTextBox = _driver.FindElement(By.XPath("//input[@name='password']"));
            PasswordTextBox.SendKeys(password);
            IWebElement LoginButton = _driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            LoginButton.Click();

        }

    }
}
