using Framework.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.UI
{
    public class Wait
    {
        private readonly Logger _logger = new Logger(typeof(Wait));

        public void IsElementPresense(By locator, TimeSpan timeout)
        {
            _logger.Debug("Wait for page loading");
            new WebDriverWait(Browser.Instance.WebDriver, timeout).Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
