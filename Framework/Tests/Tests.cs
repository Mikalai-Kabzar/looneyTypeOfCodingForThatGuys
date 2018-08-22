using Framework.Pages;
using Framework.Services;
using Framework.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        string _url = "https://comaqa.by/";
        string _message = "Sorry, no results found.";
        string _invalidEmailMessage = "Пожалуйста, введите правильный email адрес.";

        string _invalidFieldsMessage = "Ошибка! Пожалуйста проверьте поля формы.";

        string _name = "som";
        string _email = "email@mail.ru";

        string _testLangChange = "VIDEO";

        string titleForTest = "QA Conference, March 10-11, Minsk";

        public string ValidTextForSearch = "Winter 2017";
        public string InvalidText = "fufufufufuf";

        SearchPage SearchPage = new SearchPage();
        Service SearchService = new Service();
        Service Service = new Service();

        [Test]
        public void GetMessageThatSearchHasNoResults()
        {
            SearchService.GetMessageThatSearchHasNoResults(InvalidText, _url);

            Assert.That(SearchPage.GetNoResultSearchMessage, Is.EqualTo(_message));
        }

        [Test]
        public void CheckChangeLanguage()
        {
            Assert.That(Service.GetItemName(_url), Is.EqualTo(_testLangChange));
        }

        [Test]
        public void VerifyInvalidEmailMessage()
        {
            Assert.That(Service.GetInvalidEmailErrorMessage(_url, InvalidText), Is.EqualTo(_invalidEmailMessage));
        }

        [Test]
        public void VerifyInvalidFieldsMessage()
        {
            Assert.That(Service.GetInvalidFieldsErrorMessage(_url, _name, _email, InvalidText, ValidTextForSearch), 
                Is.EqualTo(_invalidFieldsMessage));
        }

        [Test]
        public void VerifyEmptySearchInput()
        {
            Assert.That(Service.CleanSearchInput(_url, InvalidText), Is.Empty);

        }

        //[Test]
        //public void VerifyAllResultItemsContainTitlesWithSearchQuery()
        //{
        //    var results = SearchService.AllResultsGetTitlesWithSeqrchQuery(ValidTextForSearch, _url);
        //    foreach(var result in results)
        //    {
        //        Assert.That(result.Title, Does.Contain(ValidTextForSearch));
        //    }
        //}

        [TearDown]
        public void CloseBrowser()
        {
            Browser.Instance.StopBrowser();
        }

        public static void Main(string[] args)
        {
        }
    }
}
