using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using ECommerceLogins.PageObjects;

namespace ECommerceLogins

{
    public class SeleniumUnsuccessfulLogon
    {
        [Test]
        public void BlankEmail()
        {
            ChromeDriver driver = new ChromeDriver();

            HomePage homePage = new HomePage(driver);
            homePage.Open();
            driver.Manage().Window.Maximize();

            homePage.SignInField.Click();

            SignInPage signInPage = new SignInPage(driver);

            signInPage.EmailAddressField.Clear();
            signInPage.EmailAddressField.SendKeys("        ");
            signInPage.PasswordField.Clear();
            signInPage.PasswordField.SendKeys("Password01");
            signInPage.SignInButton.Click();

            var BlankEmailMessage = signInPage.BlankEmailMessage;
            Assert.IsTrue(BlankEmailMessage.Text.Equals("An email address required."));

            driver.Quit();
        }

        [Test]
        public void BlankPassword()
        {
            ChromeDriver driver = new ChromeDriver();

            HomePage homePage = new HomePage(driver);
            homePage.Open();
            driver.Manage().Window.Maximize();

            homePage.SignInField.Click();

            SignInPage signInPage = new SignInPage(driver);
            Assert.AreEqual("Login - My Store", driver.Title);

            signInPage.SignInButton.Click();
            signInPage.EmailAddressField.Clear();
            signInPage.EmailAddressField.SendKeys("sd576@btinternet.com");
            signInPage.PasswordField.Clear();
            signInPage.PasswordField.SendKeys("     ");
            signInPage.SignInButton.Click();

            var BlankPasswordMessage = signInPage.BlankPasswordMessage;
            Assert.IsTrue(BlankPasswordMessage.Text.Equals("Password is required."));

            driver.Quit();
        }

        [Test]
        public void InvalidEmail()
        {
            ChromeDriver driver = new ChromeDriver();

            HomePage homePage = new HomePage(driver);
            homePage.Open();
            driver.Manage().Window.Maximize();

            homePage.SignInField.Click();

            SignInPage signInPage = new SignInPage(driver);
            Assert.AreEqual("Login - My Store", driver.Title);

            signInPage.SignInButton.Click();
            signInPage.EmailAddressField.Clear();
            signInPage.EmailAddressField.SendKeys("me@me.com");
            signInPage.PasswordField.Clear();
            signInPage.PasswordField.SendKeys("Password01");
            signInPage.SignInButton.Click();

            var InvalidEmailMessage = signInPage.InvalidEmailMessage;
            Assert.IsTrue(InvalidEmailMessage.Text.Equals("Authentication failed."));

            driver.Quit();
        }

        [Test]
        public void InvalidPassword()
        {
            ChromeDriver driver = new ChromeDriver();

            HomePage homePage = new HomePage(driver);
            homePage.Open();
            driver.Manage().Window.Maximize();

            homePage.SignInField.Click();

            SignInPage signInPage = new SignInPage(driver);
            Assert.AreEqual("Login - My Store", driver.Title);

            signInPage.SignInButton.Click();
            signInPage.EmailAddressField.Clear();
            signInPage.EmailAddressField.SendKeys("sd576@btinternet.com");
            signInPage.PasswordField.Clear();
            signInPage.PasswordField.SendKeys("Rubbish01");
            signInPage.SignInButton.Click();

            var InvalidPasswordMessage = signInPage.InvalidPasswordMessage;
            Assert.IsTrue(InvalidPasswordMessage.Text.Equals("Authentication failed."));

            driver.Quit();
        }
    }
}