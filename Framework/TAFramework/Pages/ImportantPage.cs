using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Elements;
using OpenQA.Selenium;

namespace TAFramework.Pages
{
    public class ImportantPage:BasePage
    {
        private BaseElement message = new BaseElement("tr with the message");

        public ImportantPage():base()
        {
            this.URL = "https://mail.google.com/mail/u/0/#imp";
        }

        public bool IsMessageExists(string email, string subject, int timeoutInSeconds)
        {
            message.By = By.XPath($"//tr[td[4]/div[2]/span[@email='{email}'] and td[6]/div/div/div[2]/span[1][.='{subject}']]");
            return message.IsElementPresentOnPage(7) && message.Element.Displayed;
        }
    }
}
