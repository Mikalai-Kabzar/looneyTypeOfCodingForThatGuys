using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UI.Elements
{
    public class WebElements
    {
        public By Selector;

        public List<IWebElement> BrowserElements => Browser.Instance.WebDriver.FindElements(Selector).ToList();
        public int Count => BrowserElements.Count;

        public WebElements(By selector)
        {
            Selector = selector;
        }

        public string GetText(int index)
        {
            return BrowserElements[index].Text;
        }
    }
}
