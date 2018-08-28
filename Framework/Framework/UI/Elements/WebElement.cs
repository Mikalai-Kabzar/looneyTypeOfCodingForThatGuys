using Framework.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UI.Elements
{
    public class WebElement
    {
        public By Selector;
        private readonly Logger _logger;

        Wait wait = new Wait();
        TimeSpan timeout = TimeSpan.FromMilliseconds(Config.Default.timeout);

        public IWebElement BrowserElement => Browser.Instance.FindElement(Selector);

        public WebElement(By selector)
        {
            Selector = selector;
            _logger = new Logger(typeof(WebElement));
        }

        public void Navigate(string url)
        {
            _logger.Info($"Navigate to {url}");
            Browser.Instance.WebDriver.Navigate().GoToUrl(url);
        }

        public void Click()
        {
            _logger.Info($"Click element {Selector}");
            //wait.IsElementPresense(Selector, TimeSpan.FromMilliseconds(Config.Default.timeout));
            BrowserElement.Click();
        }

        public void SendKeys(String text)
        {
            _logger.Info($"Send keys {text} to element {Selector}");
            BrowserElement.SendKeys(text);
        }

        public string GetText()
        {
            _logger.Info($"Get text of element {Selector}");
            //wait.IsElementPresense(Selector, timeout);
            return BrowserElement.Text;
        }
    }
}
