﻿using System;
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
    public class SettingsPage : BasePage
    {
        public Link LinkForwardingAndPOP { get; private set; } = new Link(By.XPath
            ("//a[contains(.,'Forwarding and POP/IMAP')]"),"link 'Forwarding and POP/IMAP'");
        public Link LlinkFiltersAndBlockedAddresses { get; private set; } = new Link(By.XPath
            ("//a[contains(.,'Filters and Blocked Addresses')]"),"link 'Filters and Blocked Addresses'");
        public Link LinkThemes { get; private set; } = new Link(By.XPath("//a[text()='Themes']"),"link 'Themes'");

        public TextInput TxtSignature { get; private set; } = new TextInput
            (By.XPath("//div[@aria-label='Signature']"),"text input 'Signature'");
        public Button BtnSaveChanges { get; private set; } = new Button
            (By.XPath("//button[text()='Save Changes' and not(ancestor::div[contains(@style, 'display: none;')])]"),"button 'Save changes'");
        public Radio RbNoSignature { get; private set; } = new Radio
            (By.XPath("//label[text()='No signature']"),"radio button 'No signature'");
        
        public Radio RbAutoReplyOn { get; private set; } = new Radio
            (By.XPath("//label[text()='Out of Office AutoReply on']"), "radio 'Out of Office AutoReply on'");
        public TextInput TxtAutoReplySubject { get; private set; } = new TextInput
            (By.XPath("//input[@aria-label='Subject']"),"text input 'AutoReply subject'");
        public TextInput TxtAutoReplyMessage { get; private set; } = new TextInput
            (By.XPath("//div[@aria-label='Out of Office AutoReply']"),"text input 'AutoReply message'");
        public Radio RbAutoReplyOff { get; private set; } = new Radio
            (By.XPath("//label[text()='Out of Office AutoReply off']"), "radio 'Out of Office AutoReply off'");

        public SettingsPage():base()
        {
            this.URL = "https://mail.google.com/mail/#settings/general";
        }
    }
}
