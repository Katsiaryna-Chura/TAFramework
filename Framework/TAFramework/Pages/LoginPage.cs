using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Pages;
using Framework.Core.Elements;
using OpenQA.Selenium;
using System.Threading;

namespace TAFramework.Pages
{
    public class LoginPage:AbstractPage
    {
        public TextInput TxtEmail { get; private set; } = new TextInput(By.Id("Email"));
        public TextInput TxtPassword { get; private set; } = new TextInput(By.Id("Passwd"));
        public Button BtnNext { get; private set; } = new Button(By.Id("next"));
        public Button BtnSignIn { get; private set; } = new Button(By.Id("signIn"));

        public Link LinkChangeAccount { get; private set; } = new Link(By.Id("account-chooser-link"));
        public Button BtnAddAccount { get; private set; } = new Button(By.XPath("//a[contains(.,'Add account')]"));

        protected readonly int timeout = 5;

        public LoginPage()
        {
            this.URL = @"https://gmail.com/";
        }

        public bool IsEmailVisible()
        {
            return TxtEmail.Element.Displayed && TxtEmail.Element.Enabled;
        }

        public void WaitForPageToLoad()
        {
            Thread.Sleep(2000);
        }
    }
}
