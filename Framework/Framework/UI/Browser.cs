using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Framework.UI.BrowserType;
using Framework.Tools;

namespace Framework.UI
{
    public class Browser
    {
        private static Browser _instanse;
        private readonly Logger _logger;
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
                            options = new PhantomJSOptions();
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
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(1);
            _logger = new Logger(typeof(Browser));
            _logger.Debug(BrowserName + " instance created");
        }

        public void MaximizeBrowserWindow()
        {
            Instance.WebDriver.Manage().Window.Maximize();
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
            _logger.Debug(BrowserName + " instance closed");
        }

        public IWebElement FindElement(By by)
        {
            return WebDriver.FindElement(by);
        }
    }
}
