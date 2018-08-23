using Framework.UI;
using Framework.UI.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class MainPage
    {
        private static readonly string SarchLinkXPathLocator = ".//i[contains(@class, 'search')]";
        private static readonly string RussianLanguageChangeItemXPathLocator = ".//a[@hreflang ='ru-RU']";
        private static readonly string EnglishLanguageChangeItemXPathLocator = ".//a[@hreflang ='en-US']";        
        private static readonly string ItemNameXPathLocator = ".//a[contains(@href, 'video')]";

        private static readonly string ContaclUsLinkXPathLocation = ".//a[contains(@href, 'contact')]";

        private WebElement SearchLink = new WebElement(By.XPath(SarchLinkXPathLocator));
        private WebElement EnglishLanguageChangeItem = new WebElement(By.XPath(EnglishLanguageChangeItemXPathLocator));
        private WebElement RussianLanguageChangeItem = new WebElement(By.XPath(RussianLanguageChangeItemXPathLocator));
        private WebElement ItemName = new WebElement(By.XPath(ItemNameXPathLocator));

        private WebElement ContactUsLink = new WebElement(By.XPath(ContaclUsLinkXPathLocation));

        public void Navigate(string url)
        {
            Browser.Instance.WebDriver.Navigate().GoToUrl(url);
        }

        public void ClickSearchLink()
        {
            SearchLink.Click();
        }

        public void ClickChangeLanguageEnglish()
        {
            EnglishLanguageChangeItem.Click();
        }

        public void ClickChangeLanguageRussian()
        {
            RussianLanguageChangeItem.Click();
        }

        public string GetItemName()
        {
            return ItemName.GetText();
        }

        public void ClickContuctUs()
        {
            ContactUsLink.Click();
        }
    }
}
