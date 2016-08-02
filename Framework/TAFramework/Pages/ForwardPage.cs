﻿using System;
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
    public class ForwardPage : BasePage
    {
        public Button BtnAddForwardingAddress { get; private set; } = new Button(By.XPath("//input[@type='button' and @act='add']"));
        public TextInput TxtForwardingAddress { get; private set; } = new TextInput(By.XPath("//div[@role='alertdialog']//input[@type='text']"));
        public Button BtnNext { get; private set; } = new Button(By.XPath("//div[@role='alertdialog']//button[@name='next']"));
        public Button BtnOk { get; private set; } = new Button(By.XPath("//div[@role='alertdialog']//button[@name='ok']"));

        //By.XPath("//button[text()='Save Changes']");
        public Button BtnSaveChanges { get; private set; } = new Button(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div/div/div/div/div/div[6]/div/table/tbody/tr[4]/td/div/button[1]"));
        public Radio RbForwardingVariant { get; private set; } = new Radio(By.XPath("//span[contains(.,'Forward a copy of incoming mail to')]/../preceding-sibling::td/input"));
        public Button BtnProceed { get; private set; } = new Button(By.XPath("//input[@type='submit']"));

        public ForwardPage():base()
        {
            this.URL = "https://mail.google.com/mail/#settings/fwdandpop";
        }

        public void ClickProceed(int timeoutInSeconds)
        {
            WebDriver.GetDriver().SwitchTo().Window(WebDriver.GetDriver().WindowHandles.Last());
            BtnProceed.Click(timeoutInSeconds);
            WebDriver.GetDriver().SwitchTo().Window(WebDriver.GetDriver().WindowHandles.First());
        }

        public void RemoveUnverifiedForwardingAddresses()
        {
            foreach(var addr in WebDriver.GetDriver().FindElements(By.XPath("//span[text()='Remove address']")))
            {
                addr.Click();
                BtnOk.Click(5);
            }
        }

        public void RemoveVerifiedForwardingAddresses()
        {
            foreach (var addr in WebDriver.GetDriver().FindElements(By.XPath("//span[contains(text(),'Forward a copy of incoming mail to')]/select/option[contains(text(),'Remove')]")))
            {
                addr.Click();
                BtnOk.Click(5);
            }
        }
    }
}
