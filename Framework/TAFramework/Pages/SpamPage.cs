using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Pages;
using Framework.Core.Elements;
using OpenQA.Selenium;
using Framework.Core.Utilities;

namespace TAFramework.Pages
{
    public class SpamPage : BasePage
    {
        public Label LblSpamMessageSubject { get; private set; } = new Label("label 'Spam message subject'");
        public Checkbox CbMessageChecker { get; private set; } = new Checkbox("checkbox for the message");
        public Button BtnNotSpam { get; private set; } = new Button
            (By.XPath("//div[@role='button' and text()='Not spam']"),"button 'Not spam'");
        public Button BtnCleanSpam { get; private set; } = new Button
            (By.XPath("//span[contains(.,'Delete all spam messages now')]"),"button 'Clean spam'");
        public Button BtnOk { get; private set; } = new Button
            (By.XPath("//div[@role='alertdialog']//button[@name='ok']"),"button 'OK'");
        public BaseElement Message { get; private set; } = new BaseElement("tr with the message");

        public SpamPage() : base()
        {
            this.URL = "https://mail.google.com/mail/u/0/#spam";
            GoToPage();
        }

        public bool IsMessageExists(string email, string subject, int timeoutInSeconds)
        {
            Message.By = By.XPath($"//tr[td[4]/div[2]/span[@email='{email}'] and td[6]/div/div/div/span[1][.='{subject}']]");
            CbMessageChecker.By = By.XPath($"//tr[td[4]/div[2]/span[@email='{email}'] and td[6]/div/div/div/span[1][.='{subject}']]/td[2]/div[@role='checkbox']");
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
    }
}
