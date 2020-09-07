using OpenQA.Selenium;

namespace ECommerceLogins.PageObjects
{
    class MyAccountPage
    {
        public MyAccountPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public string PageTitle => Driver.Title;
    }
}
