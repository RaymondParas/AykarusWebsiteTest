using AykarusWebsiteTest.Support;
using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AykarusWebsiteTest.Hooks
{
    [Binding]
    public sealed class WebDriverHook
    {
        private readonly IObjectContainer _objectContainer;
        private readonly DriverHelper _driverHelper;

        public WebDriverHook(IObjectContainer objectContainer, DriverHelper driverHelper)
        {
            _objectContainer = objectContainer;
            _driverHelper = driverHelper;
        }

        [BeforeScenario]
        public void BeforeScenario(TestContext testContext)
        {
            Console.WriteLine("Setting up web driver...");

            _driverHelper.SetupDriver(testContext.Properties["Browser"]?.ToString() ?? string.Empty);
            _objectContainer.RegisterInstanceAs(_driverHelper.Driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Disposing web driver...");

            var driver = _objectContainer.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                Console.WriteLine("Driver disposed.");
            }
        }
    }
}