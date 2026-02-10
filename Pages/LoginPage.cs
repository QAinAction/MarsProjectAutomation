using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll.BoDi;

namespace MarsProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public IWebDriver Driver => _driver;
        private readonly By SignInLink = By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a");
        private readonly By EmailAddressTextBox = By.XPath("//input[@name='email']");
        private readonly By PasswordTextBox= By.XPath("//input[@name='password']");
        private readonly By LoginButton = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button");
        

        public LoginPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
        }

        public void ClickSignInLink()
        {
            _driver.FindElement(SignInLink).Click();
        }

        public void EnterEmail(string email)
        {
            _driver.FindElement(EmailAddressTextBox).SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(PasswordTextBox).SendKeys(password);
        }
        public void ClickLoginButton()
        {
            _driver.FindElement(LoginButton).Click();
        }

        public void Login(string username, string password)
        {
            ClickSignInLink();
            EnterEmail(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        public void Invalidlogin(string username, string password)
        {
            ClickSignInLink();
            EnterEmail(username);
           EnterPassword(password);
            ClickLoginButton();
        }

        public void Skillpagelogin(string username, string password)
        {
          ClickSignInLink();
          EnterEmail(username);
          EnterEmail(password);
          ClickLoginButton();
        }

    }
}
