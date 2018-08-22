using Framework.Pages;
using Framework.Pages.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public class Service
    {
        private SearchPage SearchPage = new SearchPage();
        private MainPage MainPage = new MainPage();
        ContactUsPage ContactUsPage = new ContactUsPage();

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

        public string GetItemName(string url)
        {
            MainPage.Navigate(url);
            MainPage.ClickChangeLanguageEnglish();
            return MainPage.GetItemName();
        }

        public string GetInvalidEmailErrorMessage(string url, string email)
        {
            MainPage.Navigate(url);
            MainPage.ClickContuctUs();
            ContactUsPage.TypeEmail(email);
            ContactUsPage.ClickSendMessageButton();
            return ContactUsPage.GetInvalidEmailMessage();
        }

        public string CleanSearchInput(string url, string textForSearch)
        {
            MainPage.Navigate(url);
            MainPage.ClickSearchLink();
            SearchPage.SearchInputSendKeys(textForSearch);
            SearchPage.ClickCleanSearcInputButton();
            return SearchPage.GetSearchInputValue();
        }

        public string GetInvalidFieldsErrorMessage(string url, string name, string email, string theme, string message )
        {
            MainPage.Navigate(url);
            MainPage.ClickContuctUs();
            ContactUsPage.TypeName(name);
            ContactUsPage.TypeEmail(email);
            ContactUsPage.TypeTheme(theme);
            ContactUsPage.TypeMessage(message);
            ContactUsPage.ClickSendMessageButton();
            return ContactUsPage.GetInvalidFieldsMessage();
        }
    }
}
