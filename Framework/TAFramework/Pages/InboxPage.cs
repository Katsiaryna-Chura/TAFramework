using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Pages;
using Framework.Core.Elements;
using OpenQA.Selenium;
using Framework.Core.Extensions;
using Framework.Core.Utilities;

namespace TAFramework.Pages
{
    class InboxPage : BasePage
    {
        public Checkbox CbMessageChecker { get; private set; } = new Checkbox();
        public Button BtnReportSpam { get; private set; } = new Button(By.XPath("//div[@class = 'asl T-I-J3 J-J5-Ji']"));//"//div[@data-tooltip='Report spam')]"
        public Button BtnDelete { get; private set; } = new Button(By.XPath("//div[@class='ar9 T-I-J3 J-J5-Ji']"));//div[@aria-label='Delete']

        public Link LinkToMessage { get; private set; } = new Link();
        public BaseElement Message { get; private set; } = new BaseElement();
        public Button BtnRefresh { get; private set; } = new Button(By.XPath("//div[@class='asf T-I-J3 J-J5-Ji']"));//div[@aria-label='Refresh']

        public InboxPage() : base()
        {
            this.URL = "https://mail.google.com/mail/u/0/#inbox";
        }

        private void MessageInitialize(string email)// rename
        {
            LinkToMessage.By = By.XPath($"//tr/td[4]/div[2][span[@email='{email}']]");
            CbMessageChecker.By = By.XPath($"//tr[td[4]/div[2]/span[@email='{email}']]/td[2]/div[@role='checkbox']");
        }

        public void CheckMessageChecker(string email, int timeoutInSeconds)
        {
            MessageInitialize(email);
            CbMessageChecker.Select(timeoutInSeconds);
        }

        public void GoToMessagePage(string email, int timeoutInSeconds)
        {
            MessageInitialize(email);
            LinkToMessage.Click(timeoutInSeconds);
        }

        public bool IsMessageExists(string email, string subject, int timeoutInSeconds)
        {
            Message.By = By.XPath($"//tr[td[4]/div[2]/span[@email='{email}'] and td[6]/div/div/div/span[1][.='{subject}']]");
            return Message.IsElementPresentOnPage(7) && Message.Element.Displayed;
        }

        public bool SelectAllMessages()
        {
            bool result = false;
            foreach (var cb in WebDriver.GetDriver().FindElements(By.XPath("//tr[td[4]/div[2]/span[@email]]/td[2]/div[@role='checkbox']")))
            {
                if (!cb.Selected)
                {
                    cb.Click();
                    result = true;
                }
            }
            return result;
        }

        public void MarkMessageAsStarred(string email, string subject)
        {
            WebDriver.GetDriver().FindElement(By.XPath($"//tr[td[4]/div[2]/span[@email='{email}'] and td[6]/div/div/div/span[1][.='{subject}']]//span[@aria-label='Not starred']"),7).Click();
        }
    }
}
