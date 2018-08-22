using Project.Pages;
using Project.Pages.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.Services
{
    public class SearchService
    {
        private SearchPage SearchPage = new SearchPage();
        private MainPage MainPage = new MainPage();
        
        public void GetMessageThatSearchHasNoResults(string textForSearch, string url)
        {
            MainPage.Navigate(url);
            MainPage.ClickSearchLink();
            SearchPage.SearchInputSendKeys(textForSearch);
            SearchPage.EnterButtonEmulate();
        }   
        
        public List<SearchResult> AllResultsGetTitlesWithSeqrchQuery(string textForSearch, string url)
        {
            MainPage.Navigate(url);
            MainPage.ClickSearchLink();
            SearchPage.SearchInputSendKeys(textForSearch);
            SearchPage.EnterButtonEmulate();
            return SearchPage.GetSearchResultHeaders();
        }
    }
}
