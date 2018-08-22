using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Project.UI;
using Project.Services;
using Project.Pages;

namespace Tests
{
    [TestFixture]
    public class TestSearch
    {
        string _url = "https://comaqa.by/";
        string _message = "Sorry, no results found.";

        public string ValidTextForSearch = "Winter 2017";
        public string InvalidTextForSearch = "fufufu";

        SearchPage SearchPage = new SearchPage();
        SearchService SearchService = new SearchService();

        [Test]
        public void GetMessageThatSearchHasNoResults()
        {
            SearchService.GetMessageThatSearchHasNoResults(InvalidTextForSearch, _url);

            Assert.That(SearchPage.GetNoResultSearchMessage, Is.EqualTo(_message));
        }

        [Test]
        public void VerifyAllResultItemsContainTitlesWithSearchQuery()
        {
            var results = SearchService.AllResultsGetTitlesWithSeqrchQuery(ValidTextForSearch, _url);
            foreach(var result in results)
            {
                Assert.That(result.Title, Does.Contain(ValidTextForSearch));
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            Browser.Instance.StopBrowser();
        }
    }
}
