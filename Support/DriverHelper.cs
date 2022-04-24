using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AykarusWebsiteTest.Support
{
    public class DriverHelper
    {
        public IWebDriver? Driver { get; private set; }

        public DriverHelper() { Driver = null; }

        public void SetupDriver(string browser)
        {
            switch (browser.ToLower().Trim())
            {
                case "chrome":
                    Driver = SetupChromeDriver();
                    break;
                default:
                    throw new ArgumentException($"{browser} browser not supported");
            }

            Driver.Manage().Window.Maximize();
        }

        public static ChromeDriver SetupChromeDriver()
        {
            var options = new ChromeOptions()
            {
                AcceptInsecureCertificates = true,
            };

            options.AddArguments(new List<string>()
            {
                "--start-maximized",
                "--disable-extensions",
                "--disable-popup-blocking",
                "--window-size=1080,1920",
                "--no-sandbox",
                "--disable-infobars",
                "--disable-dev-shm-usage",
                "--disable-browser-side-navigation",
                "--disable-gpu",
                "--ignore-certificate-errors"
        });

            return new ChromeDriver(options);
        }

    }
}
