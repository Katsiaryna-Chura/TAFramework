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
using System.Threading;

namespace TAFramework.Pages
{
    public class MessagePage : BasePage
    {
        public Button BtnReportSpam { get; private set; } = new Button(By.XPath("//div[@role='button' and @data-tooltip='Report spam']"));
        private Button btnConfirm = new Button(By.XPath("//input[@value='Confirm']"));
        public Link LinkGoToConfirmation { get; private set; } = new Link(By.XPath("//a[4]"));//div[@class='ii gt adP adO']//a[4]
        public Label LblMessageBody { get; private set; } = new Label(By.XPath("//div[@class='adn ads']")); 

        public MessagePage():base()
        {
            this.URL = "https://mail.google.com/mail/u/0/#inbox";
        }

        //public void ClickGoToConfirmationLink(int timeoutInSeconds)
        //{
        //    Link linkGoToConfirmation = new Link(By.XPath("//a[4]"));//or "//div[@class='ii gt adP adO']//a[4]"
        //    linkGoToConfirmation.Click(timeoutInSeconds);
        //}

        public void ClickConfirm(int timeoutInSeconds)
        {
            WebDriver.GetDriver().SwitchTo().Window(WebDriver.GetDriver().WindowHandles.Last());
            btnConfirm.Click(timeoutInSeconds);
            Thread.Sleep(2000);
            WebDriver.GetDriver().Close();
            WebDriver.GetDriver().SwitchTo().Window(WebDriver.GetDriver().WindowHandles.First());
        }

        public int GetNumberOfEmoticonsInMessage(int timeoutInSeconds)
        {
            return WebDriver.GetDriver().FindElements(By.XPath("//img[@class='CToWUd']"), timeoutInSeconds).Count();
        }
    }
}
