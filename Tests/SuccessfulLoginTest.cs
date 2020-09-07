using System.IO;
using System.Reflection;
using ECommerceLogins.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace ECommerceLogins.Tests
{
    public class SeleniumLoginSuccess
    {
        [Test]
        public void LoginSuccess()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ChromeDriver driver = new ChromeDriver(path);

            HomePage homePage = new HomePage(driver);
            homePage.Open();
            driver.Manage().Window.Maximize();
            Assert.AreEqual("My Store", driver.Title);

            homePage.SignInField.Click();

            SignInPage signInPage = new SignInPage(driver);
            Assert.AreEqual("Login - My Store", driver.Title);

            signInPage.EmailAddressField.SendKeys("sd576@btinternet.com");
            signInPage.PasswordField.SendKeys("Password01");
            signInPage.SignInButton.Click();

            Assert.AreEqual("Login - My Store", driver.Title);

            driver.Quit();
        }
    }
}
