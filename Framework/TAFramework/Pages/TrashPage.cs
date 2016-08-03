using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Elements;
using OpenQA.Selenium;
using Framework.Core.Utilities;
using Framework.Core.Extensions;

namespace TAFramework.Pages
{
    public class TrashPage:BasePage
    {
        private BaseElement message = new BaseElement();
        public Button BtnCleanTrash { get; private set; } = new Button(By.XPath("//span[text()='Empty Bin now']"));
        public Button BtnOk { get; private set; } = new Button(By.XPath("//button[@name='ok']"));
        public Button BtnDeleteForever = new Button(By.XPath
            ("//div[text()='Delete forever' and not(ancestor::div[contains(@style, 'display: none;')])]"));

        public TrashPage():base()
        {
            this.URL = "https://mail.google.com/mail/u/0/#trash";
            GoToPage();
        }

        public bool IsMessageExists(string email, string subject, int timeoutInSeconds)
        {
            message.By = By.XPath($"//tr[td[4]/div[2]/span[@email='{email}'] and td[6]/div/div/div/span[1][.='{subject}']]");
            return message.IsElementPresentOnPage(7) && message.Element.Displayed;
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
    }
}
