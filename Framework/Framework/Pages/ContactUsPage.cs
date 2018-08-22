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

        private WebElement InputName = new WebElement(By.CssSelector(InputNameCSSLocator));
        private WebElement InputEmail = new WebElement(By.CssSelector(InputEmailCSSLocator));
        private WebElement InputTheme = new WebElement(By.CssSelector(InputThemeCSSLocator));
        private WebElement InputMessgae = new WebElement(By.CssSelector(InputMessageCSSLocator));
        
        private WebElement InvalidEmailMessage = new WebElement(By.XPath(InvalidEmailMessageXPathLocator));
        private WebElement InvalidFieldsMessage = new WebElement(By.CssSelector(InvalidFieldsMessageCSSLocator));

        private WebElement SendMessageButton = new WebElement(By.CssSelector(SendMessageButtonCSSLocator));

        private TimeSpan timeout = TimeSpan.FromMilliseconds(Config.Default.timeout);

        public void TypeName(string name)
        {
            InputName.SendKeys(name);
        }

        public void TypeEmail(string email)
        {
            InputEmail.SendKeys(email);
        }

        public void TypeTheme(string theme)
        {
            InputTheme.SendKeys(theme);
        }

        public void TypeMessage(string message)
        {
            InputMessgae.SendKeys(message);
        }

        public void ClickSendMessageButton()
        {
            SendMessageButton.Click();
        }

        public string GetInvalidEmailMessage()
        {
            Wait.IsElementPresense(By.XPath(InvalidEmailMessageXPathLocator), timeout);
            return InvalidEmailMessage.GetText();
        }

        public string GetInvalidFieldsMessage()
        {
            Wait.IsElementPresense(By.CssSelector(InvalidFieldsMessageCSSLocator), timeout);
            return InvalidFieldsMessage.GetText();
        }
    }
}
