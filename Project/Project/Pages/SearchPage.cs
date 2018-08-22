using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.UI.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using Project.Pages.Objects;
using Project.UI;

namespace Project.Pages
{
    public class SearchPage
    {
        private static readonly string SearchInputXPathLocator = ".//input[@class='ui-menu ui-autocomplete-input']";
        private static readonly string SearchResultsIdLocator = "wpus_response";
        private static readonly string SearchTitleResultsXPathLocator = ".//div[@id='wpus_response']//h2/a";
        private static readonly string NoResultMessageXPathLocator = ".//div[@class='wpus-no-results']"; 

        private WebElement SearchInput = new WebElement(By.XPath(SearchInputXPathLocator));
        private WebElements SearchResults = new WebElements(By.Id(SearchResultsIdLocator));
        private WebElements SearchTitleResults = new WebElements(By.XPath(SearchTitleResultsXPathLocator));
        private WebElement NoResultMessage = new WebElement(By.XPath(NoResultMessageXPathLocator));

        private TimeSpan timeout = TimeSpan.FromMilliseconds(Config.Default.timeout);

        public void SearchInputSendKeys(String text)
        {
            SearchInput.SendKeys(text);
        }

        public void EnterButtonEmulate()
        {            
            SearchInput.SendKeys(Keys.Enter);
        }

        public string GetNoResultSearchMessage()
        {
            Wait.IsElementPresense(By.XPath(NoResultMessageXPathLocator), timeout);
            return NoResultMessage.GetText();
        }

        public List<SearchResult> GetSearchResultHeaders()
        {
            List<SearchResult> searchResultList = new List<SearchResult>();
            for (int i = 0; i < SearchResults.Count; i++)
            {
                searchResultList.Add(new SearchResult { Title = SearchTitleResults.GetText(i) });
            }
            return searchResultList;
        }


    }
}
