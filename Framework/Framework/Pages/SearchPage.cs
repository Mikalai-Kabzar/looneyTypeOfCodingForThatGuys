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

        private WebElement SearchInput = new WebElement(By.XPath(SearchInputXPathLocator));
        private WebElements SearchResults = new WebElements(By.Id(SearchResultsIdLocator));
        private WebElement NoResultMessage = new WebElement(By.XPath(NoResultMessageXPathLocator));

        private WebElement CleanSearchInputButton = new WebElement(By.XPath(CleanSearchInputXPathLocator));

        private TimeSpan timeout = TimeSpan.FromMilliseconds(Config.Default.timeout);
        private Wait wait = new Wait();

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
            wait.IsElementPresense(By.XPath(NoResultMessageXPathLocator), timeout);
            return NoResultMessage.GetText();
        }

        public void ClickCleanSearcInputButton()
        {
            CleanSearchInputButton.Click();
        }

        public string GetSearchInputValue()
        {
            return SearchInput.GetText();
        }
    }
}
