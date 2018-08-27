using Framework.Pages;
using Framework.UI.Elements;

namespace Framework.Services
{
    public class Service
    {
        private SearchPage SearchPage = new SearchPage();
        private MainPage MainPage = new MainPage();
        private ContactUsPage ContactUsPage = new ContactUsPage();

        public void GetMessageThatSearchHasNoResults(string textForSearch, string url)
        {
            MainPage.Navigate(url);
            MainPage.SearchLink.Click();
            SearchPage.SearchInput.SendKeys(textForSearch);
            SearchPage.EnterButtonEmulate();
        }

        public string GetItemName(string url)
        {
            MainPage.Navigate(url);
            //MainPage.ClickChangeLanguageEnglish();
            MainPage.RussianLanguageChangeItem.Click();
            return MainPage.ItemName.GetText();
        }

        public string GetInvalidEmailErrorMessage(string url, string email)
        {
            MainPage.Navigate(url);
            MainPage.ContactUsLink.Click();
            ContactUsPage.InputEmail.SendKeys(email);
            ContactUsPage.SendMessageButton.Click();
            return ContactUsPage.InvalidEmailMessage.GetText();
        }

        public string CleanSearchInput(string url, string textForSearch)
        {
            MainPage.Navigate(url);
            MainPage.SearchLink.Click();
            SearchPage.SearchInput.SendKeys(textForSearch);
            SearchPage.CleanSearchInputButton.Click();
            return SearchPage.SearchInput.GetText();
        }

        public string GetInvalidFieldsErrorMessage(string url, string name, string email, string theme, string message )
        {
            MainPage.Navigate(url);
            MainPage.ContactUsLink.Click();
            ContactUsPage.InputName.SendKeys(name);
            ContactUsPage.InputEmail.SendKeys(email);
            ContactUsPage.InputTheme.SendKeys(theme);
            ContactUsPage.InputMessgae.SendKeys(message);
            ContactUsPage.SendMessageButton.Click();
            return ContactUsPage.InvalidFieldsMessage.GetText();
        }
    }
}
