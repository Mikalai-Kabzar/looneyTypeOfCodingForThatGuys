using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Project.UI.Elements
{
    class WebElement
    {
        public By Selector;

        public IWebElement BrowserElement => Browser.Instance.FindElement(Selector);

        public WebElement(By selector)
        {
            Selector = selector; 
        }

        public void Navigate(string url)
        {
            Browser.Instance.WebDriver.Navigate().GoToUrl(url);
        }

        public void Click()
        {
            BrowserElement.Click();
        }

        public void SendKeys(String text)
        {
            BrowserElement.SendKeys(text);
        }

        public string GetText()
        {
            return BrowserElement.Text;
        }
    }
}
