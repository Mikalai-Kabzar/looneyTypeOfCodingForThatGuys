using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Framework.UI.BrowserType;

namespace Framework.UI
{
    public class Browser
    {
        private static Browser _instanse;
        private static string BrowserName = Config.Default.Browser;

        public readonly IWebDriver WebDriver;

        public static Browser Instance
        {
            get
            {
                if (_instanse is null)
                {
                    Driver browser;
                    DriverOptions options;

                    switch (BrowserName)
                    {
                        case "CHROME":
                            browser = Driver.CHROME;
                            options = new ChromeOptions();
                            break;
                        case "FIREFOX":
                            browser = Driver.FIREFOX;
                            options = new FirefoxOptions();
                            break;
                        case "EDGE":
                            browser = Driver.EDGE;
                            options = new EdgeOptions();
                            break;
                        default:
                            browser = Driver.CHROME;
                            options = new ChromeOptions();
                            break;
                    }

                    _instanse = new Browser(WebDriverFactory.GetDriver(browser, options));
                }
                return _instanse;
            }
        }

        public Browser(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public void MaximizeBrowserWindow()
        {
            Instance.WebDriver.Manage().Window.FullScreen();
        }

        public void StopBrowser()
        {
            try
            {
                if (WebDriver != null)
                {
                    WebDriver.Quit();
                }
            }
            finally
            {
                _instanse = null;
            }
        }

        public IWebElement FindElement(By by)
        {
            return WebDriver.FindElement(by);
        }
    }
}
