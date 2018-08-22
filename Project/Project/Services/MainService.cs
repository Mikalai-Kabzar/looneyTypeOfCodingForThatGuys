using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Project.UI.Elements;

namespace Project.Services
{
    public class MainService
    {
        private static readonly string SearchIconXPathLocator = ".//li/a[contains(@href, 'search')]";

        private WebElement SearchIcon = new WebElement(By.XPath(SearchIconXPathLocator));

        public void ClickSearchIcon()
        {
            SearchIcon.Click();
        }
    }
}
