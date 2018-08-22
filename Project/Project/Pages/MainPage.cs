using OpenQA.Selenium;
using Project.UI;
using Project.UI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Pages
{
    class MainPage
    {
        private static readonly string SarchLinkXPathhLocator = ".//i[contains(@class, 'search')]";

        private WebElement SearchLink = new WebElement(By.XPath(SarchLinkXPathhLocator));

        public void Navigate(string url)
        {
            Browser.Instance.WebDriver.Navigate().GoToUrl(url);
        }

        public void ClickSearchLink()
        {
            SearchLink.Click();
        }
    }
}
