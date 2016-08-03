using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class LoginPageSteps
    {
        public static void OpenGmail()
        {
            LoginPage page = new LoginPage();
            page.GoToPage();
        }

        public static void LoginUser(string email, string password)
        {
            LoginPage page = new LoginPage();
            if (!page.TxtEmail.IsElementPresentOnPage(10))
            {
                page.BtnAddAccount.Click(7);
            }
            else if (!page.IsEmailVisible())
            {
                page.LinkChangeAccount.Click(10);
                page.BtnAddAccount.Click(10);
            }
            page.TxtEmail.TypeText(email, 7);
            page.BtnNext.Click(7);
            page.WaitForPageToLoad();
            page.TxtPassword.TypeText(password, 7);
            page.BtnSignIn.Click(7);
        }

        public static void SwitchUser(string email, string password)
        {
            BaseSteps.SignOut();
            LoginPageSteps.LoginUser(email, password);
        }
    }
}
