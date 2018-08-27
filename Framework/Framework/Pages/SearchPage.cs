using Framework.UI;
using Framework.UI.Elements;
using OpenQA.Selenium;
using System;

namespace Framework.Pages
{
    public class SearchPage
    {
        private static readonly string SearchInputXPathLocator = ".//input[@class='ui-menu ui-autocomplete-input']";
        private static readonly string SearchResultsIdLocator = "wpus_response";
        private static readonly string NoResultMessageXPathLocator = ".//div[@class='wpus-no-results']";

        private static readonly string CleanSearchInputXPathLocator = ".//div[@title='clear search']";

        public WebElement SearchInput = new WebElement(By.XPath(SearchInputXPathLocator));
        public WebElements SearchResults = new WebElements(By.Id(SearchResultsIdLocator));
        public WebElement NoResultMessage = new WebElement(By.XPath(NoResultMessageXPathLocator));

        public WebElement CleanSearchInputButton = new WebElement(By.XPath(CleanSearchInputXPathLocator));
      
        public void EnterButtonEmulate()
        {
            SearchInput.SendKeys(Keys.Enter);
        }
    }
}
