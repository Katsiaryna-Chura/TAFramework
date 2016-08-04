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
        public TextInput TxtEmail { get; private set; } = new TextInput(By.Id("Email"),"text input 'Email'");
        public TextInput TxtPassword { get; private set; } = new TextInput(By.Id("Passwd"),"text input 'Password'");
        public Button BtnNext { get; private set; } = new Button(By.Id("next"),"button 'Next'");
        public Button BtnSignIn { get; private set; } = new Button(By.Id("signIn"),"button 'Sign in'");

        public Link LinkChangeAccount { get; private set; } = new Link
            (By.Id("account-chooser-link"),"link 'Change account'");
        public Button BtnAddAccount { get; private set; } = new Button
            (By.XPath("//a[contains(.,'Add account')]"),"button 'Add account'");

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
