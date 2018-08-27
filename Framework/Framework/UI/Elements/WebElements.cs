using Framework.Tools;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Framework.UI.Elements
{
    public class WebElements
    {
        public By Selector;
        private readonly Logger _logger;

        public List<IWebElement> BrowserElements => Browser.Instance.WebDriver.FindElements(Selector).ToList();
        public int Count => BrowserElements.Count;

        public WebElements(By selector)
        {
            Selector = selector;
            _logger = new Logger(typeof(WebElement));
        }

        public string GetText(int index)
        {
            _logger.Debug($"Get text from elements {Selector} with index {index}");
            return BrowserElements[index].Text;
        }
    }
}
