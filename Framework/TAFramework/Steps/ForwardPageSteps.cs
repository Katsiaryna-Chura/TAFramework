using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class ForwardPageSteps
    {
        public static void GoToForwardPage()
        {
            ForwardPage page = new ForwardPage();
            page.GoToPage();
        }

        public static void AddForwardingAddress(string email)
        {
            ForwardPage page = new ForwardPage();
            page.BtnAddForwardingAddress.Click(7);
            page.TxtForwardingAddress.TypeText(email, 7);
            page.BtnNext.Click(7);
            page.ClickProceed(7);
            page.BtnOk.Click(7);
        }

        public static void ChooseForwardingVariant()//rename
        {
            ForwardPage page = new ForwardPage();
            page.RbForwardingVariant.Select(7);
            page.BtnSaveChanges.Click(7);

            Thread.Sleep(2000);
        }

        public static void DeleteAllForwardingAddresses()
        {
            GoToForwardPage();
            ForwardPage page = new ForwardPage();
            page.RemoveUnverifiedForwardingAddresses();
            page.RemoveVerifiedForwardingAddresses();
            page.WaitForPageToLoad();
        }
    }
}
