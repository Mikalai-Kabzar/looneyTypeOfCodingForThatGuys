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
using System.Drawing;

namespace Framework.UI
{
    public class Browser
    {
        private static Browser _instanse;
        private readonly Logger _logger;
        private static string BrowserName = Config.Default.Browser;

        private Wait wait = new Wait();

        public readonly IWebDriver WebDriver;

        public static Browser Instance
        { 
            get
            {
                if (_instanse is null)
                {
                    Logger.Init();
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
                        case "PHANTOMJS":
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
            WebDriver.Manage().Window.Size = new Size(1920, 1080);
            _logger = new Logger(typeof(Browser));
            _logger.Debug(BrowserName + " instance created");
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
            wait.IsElementPresense(by, TimeSpan.FromMilliseconds(Config.Default.timeout));
            return WebDriver.FindElement(by);
        }
    }
}
