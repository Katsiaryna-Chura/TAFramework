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
        public Checkbox CbMessageChecker { get; private set; } = new Checkbox("checkbox for the message");
        public Button BtnReportSpam { get; private set; } = new Button
            (By.XPath("//div[@class = 'asl T-I-J3 J-J5-Ji']"),"button 'Report spam'");//div[@data-tooltip='Report spam')] doesn't work
        public Button BtnDelete { get; private set; } = new Button
            (By.XPath("//div[@class='ar9 T-I-J3 J-J5-Ji']"),"button 'Delete'");//div[@aria-label='Delete'] doesn't work

        public Link LinkToMessage { get; private set; } = new Link("link to the message");
        public BaseElement Message { get; private set; } = new BaseElement("tr with the message");
        public Button BtnRefresh { get; private set; } = new Button
            (By.XPath("//div[@class='asf T-I-J3 J-J5-Ji']"),"button 'Refresh'");//div[@aria-label='Refresh'] doesn't work

        public InboxPage() : base()
        {
            this.URL = "https://mail.google.com/mail/u/0/#inbox";
        }

        private void MessageInitialize(string email, string subject)
        {
            LinkToMessage.By = By.XPath($"//tr[td[6]/div/div/div/span[1][.='{subject}']]/td[4]/div[2][span[@email='{email}']]");
            CbMessageChecker.By = By.XPath($"//tr[td[4]/div[2]/span[@email='{email}'] and td[6]/div/div/div/span[1][.='{subject}']]/td[2]/div[@role='checkbox']");
        }

        public void CheckMessageChecker(string email, string subject, int timeoutInSeconds)
        {
            MessageInitialize(email, subject);
            CbMessageChecker.Select(timeoutInSeconds);
        }

        public void GoToMessagePage(string email, string subject, int timeoutInSeconds)
        {
            MessageInitialize(email, subject);
            LinkToMessage.Click(timeoutInSeconds);
        }

        public void GoToMessagePage(string email, int timeoutInSeconds)
        {
            LinkToMessage.By = By.XPath($"//tr/td[4]/div[2][span[@email='{email}']]");
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
                if (cb.Displayed && !cb.Selected)
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
