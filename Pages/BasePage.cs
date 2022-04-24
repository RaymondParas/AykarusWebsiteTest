using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AykarusWebsiteTest.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void GoTo(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("URL cannot be null or empty");

            Console.WriteLine($"Accessing URL '{url}'");
            Driver.Navigate().GoToUrl(url);
            WaitForPageLoad();
        }

        public void WaitForPageLoad(int timeoutSeconds = 60)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
