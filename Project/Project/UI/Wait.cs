using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UI
{
    public class Wait
    {
        public static void IsElementPresense(By locator, TimeSpan timeout)
        {
            new WebDriverWait(Browser.Instance.WebDriver, timeout)
                .Until(driver => driver.FindElement(locator).Displayed);
        }
    }
}
