using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Project.UI
{
    public class WebDriverFactory
    {
        public readonly IWebDriver WebDriver;

        public static IWebDriver GetDriver(Driver driverType, DriverOptions options)
        {            
            var directory = AppDomain.CurrentDomain.BaseDirectory + Config.Default.directory;
            var timeout = TimeSpan.FromMilliseconds(Config.Default.timeout);
            switch (driverType)
            {
                case Driver.CHROME:
                    return new ChromeDriver(ChromeDriverService.CreateDefaultService(directory), options as ChromeOptions, timeout);
                    //case Driver.Firefox:
                    //    return new FirefoxDriver(FirefoxDriverService.CreateDefaultService(directory), options as FirefoxOptions, timeout);
            }

            return null;
        }
    }
}