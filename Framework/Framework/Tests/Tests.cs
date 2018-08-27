using Framework.Pages;
using Framework.Services;
using Framework.UI;
using log4net;
using NUnit.Allure.Core;
using NUnit.Framework;
using System.Net;

namespace Tests
{
    [TestFixture]
    [AllureNUnit]
    public class Tests
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Tests));

        string _url = "https://comaqa.by/";
        string _message = "Sorry, no results found.";
        string _invalidEmailMessageRu = "Пожалуйста, введите правильный email адрес.";
        string _invalidEmailMessage = "Please enter a valid email address.";

        string _invalidFieldsMessageRu = "Ошибка! Пожалуйста проверьте поля формы.";
        string _invalidFieldsMessage = "Error! Please check form fields.";

        string _name = "som";
        string _email = "email@mail.ru";

        string _testLangChange = "ВИДЕО";
        string _testLangChangeEn = "VIDEO";

        public string ValidTextForSearch = "Winter 2017";
        public string InvalidText = "fufufufufuf";

        SearchPage SearchPage = new SearchPage();
        Service SearchService = new Service();
        Wait wait = new Wait();
        Service Service = new Service();

        [SetUp]
        public void Init()
        {
            log.Info("Test starting...");
        }

        [Test]
        public void GetMessageThatSearchHasNoResults()
        {
            SearchService.GetMessageThatSearchHasNoResults(InvalidText, _url);

            Assert.That(SearchPage.NoResultMessage.GetText, Is.EqualTo(_message));
        }

        [Test]
        public void GetMessageThatSearchHasNoResultsFail()
        {
            SearchService.GetMessageThatSearchHasNoResults(InvalidText, _url);

            Assert.That(SearchPage.NoResultMessage.GetText, Is.Empty);
        }

        [Test]
        public void CheckChangeLanguage()
        {
            Assert.That(Service.GetItemName(_url), Is.EqualTo(_testLangChange));
        }

        [Test]
        public void CheckChangeLanguageFail()
        {
            Assert.That(Service.GetItemName(_url), Is.EqualTo(_testLangChangeEn));
        }

        [Test]
        public void VerifyInvalidEmailMessage()
        {
            Assert.That(Service.GetInvalidEmailErrorMessage(_url, InvalidText), Is.EqualTo(_invalidEmailMessage));
        }

        [Test]
        public void VerifyInvalidEmailMessageFail()
        {
            Assert.That(Service.GetInvalidEmailErrorMessage(_url, InvalidText), Is.EqualTo(_invalidEmailMessageRu));
        }

        [Test]
        public void VerifyInvalidFieldsMessage()
        {
            Assert.That(Service.GetInvalidFieldsErrorMessage(_url, _name, _email, InvalidText, ValidTextForSearch),
                Is.EqualTo(_invalidFieldsMessage));
        }

        [Test]
        public void VerifyInvalidFieldsMessageFail()
        {
            Assert.That(Service.GetInvalidFieldsErrorMessage(_url, _name, _email, InvalidText, ValidTextForSearch),
                Is.EqualTo(_invalidFieldsMessageRu));
        }

        [Test]
        public void VerifyEmptySearchInput()
        {
            Assert.That(Service.CleanSearchInput(_url, InvalidText), Is.Empty);
        }

        [Test]
        public void VerifyEmptySearchInputFail()
        {
            Assert.That(Service.CleanSearchInput(_url, InvalidText), Is.EqualTo(InvalidText));
        }

        [TearDown]
        public void CloseBrowser()
        {
            log.Info("Test ending...");
            Browser.Instance.StopBrowser();
        }
    }
}
