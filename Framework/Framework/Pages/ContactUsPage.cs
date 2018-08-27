using Framework.UI;
using Framework.UI.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class ContactUsPage
    {
        private static readonly string InputNameCSSLocator = "#contact-form-name";
        private static readonly string InputEmailCSSLocator = "#contact-form-email";
        private static readonly string InputThemeCSSLocator = "#contact-form-subject";
        private static readonly string InputMessageCSSLocator = "#contact-form-message";

        private static readonly string InvalidEmailMessageXPathLocator = ".//p[@class='contact-form-email']/label[@class='error']";
        private static readonly string InvalidFieldsMessageCSSLocator = ".contact-form-header";

        private static readonly string SendMessageButtonCSSLocator = "#contact-form-submit";

        public WebElement InputName = new WebElement(By.CssSelector(InputNameCSSLocator));
        public WebElement InputEmail = new WebElement(By.CssSelector(InputEmailCSSLocator));
        public WebElement InputTheme = new WebElement(By.CssSelector(InputThemeCSSLocator));
        public WebElement InputMessgae = new WebElement(By.CssSelector(InputMessageCSSLocator));
        
        public WebElement InvalidEmailMessage = new WebElement(By.XPath(InvalidEmailMessageXPathLocator));
        public WebElement InvalidFieldsMessage = new WebElement(By.CssSelector(InvalidFieldsMessageCSSLocator));

        public WebElement SendMessageButton = new WebElement(By.CssSelector(SendMessageButtonCSSLocator));
    }
}
