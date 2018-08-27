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

        public WebElement SearchLink = new WebElement(By.XPath(SarchLinkXPathLocator));
        public WebElement EnglishLanguageChangeItem = new WebElement(By.XPath(EnglishLanguageChangeItemXPathLocator));
        public WebElement RussianLanguageChangeItem = new WebElement(By.XPath(RussianLanguageChangeItemXPathLocator));
        public WebElement ItemName = new WebElement(By.XPath(ItemNameXPathLocator));

        public WebElement ContactUsLink = new WebElement(By.XPath(ContaclUsLinkXPathLocation));

        public void Navigate(String url)
        {
            Browser.Instance.WebDriver.Navigate().GoToUrl(url);
        }
    }
}
