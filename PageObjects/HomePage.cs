using OpenQA.Selenium;

namespace ECommerceLogins.PageObjects
{
    class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
        public IWebElement SignInField => Driver.FindElement(By.ClassName("login"));

        internal void Open()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
    }
}
