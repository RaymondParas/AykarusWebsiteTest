using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AykarusWebsiteTest.Support
{
    public static class ElementHelper
    {
        public static bool WaitUntil(Func<IWebDriver, bool> func, IWebDriver driver, int timeoutSeconds, int pollingIntervalMilliseconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalMilliseconds)
            };

            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            return wait.Until(func);
        }

        public static IWebElement FindElementExt(this IWebDriver driver, By locator, int timeoutSeconds = 10, int pollingIntervalMilliseconds = 500)
        {
            if (timeoutSeconds > 0)
            {
                WaitUntil(d =>
                {
                   return d.FindElement(locator) != null;
                }, driver, timeoutSeconds, pollingIntervalMilliseconds);
            }

            return driver.FindElement(locator);
        }

        public static IWebElement WaitUntilClickable(this IWebDriver driver, By locator, int timeoutSeconds = 10, int pollingIntervalMilliseconds = 500)
        {
            if (timeoutSeconds > 0)
            {
                WaitUntil(d =>
                {
                    var element = d.FindElement(locator);
                    return element != null && element.Displayed && element.Displayed;
                }, driver, timeoutSeconds, pollingIntervalMilliseconds);
            }

            return driver.FindElement(locator);
        }

        public static IWebElement WaitUntilVisible(this IWebDriver driver, By locator, int timeoutSeconds = 10, int pollingIntervalMilliseconds = 500)
        {
            if (timeoutSeconds > 0)
            {
                WaitUntil(d =>
                {
                    var element = d.FindElement(locator);
                    return element != null && element.Size.Width != 0 && element.Size.Height != 0;
                }, driver, timeoutSeconds, pollingIntervalMilliseconds);
            }

            return driver.FindElement(locator);
        }

        public static IWebElement WaitForText(this IWebDriver driver, By locator, int timeoutSeconds = 10, int pollingIntervalMilliseconds = 500)
        {
            if (timeoutSeconds > 0)
            {
                WaitUntil(d =>
                {
                    var element = d.FindElement(locator);
                    return element != null && !string.IsNullOrWhiteSpace(element.Text);
                }, driver, timeoutSeconds, pollingIntervalMilliseconds);
            }

            return driver.FindElement(locator);
        }
    }
}
