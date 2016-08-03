using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class SpamPageSteps
    {
        public static bool IsMessagePresentInSpam(string email, string subject)
        {
            SpamPage page = new SpamPage();
            page.WaitForPageToLoad();
            return page.IsMessageExists(email, subject,7);
        }

        public static void MoveMessageToInbox(string email,string subject)
        {
            SpamPage page = new SpamPage();
            page.WaitForPageToLoad();
            while (page.IsMessageExists(email,subject, 7))
            {
                page.CbMessageChecker.Select(7);
                page.BtnNotSpam.Click(7);
            }
        }

        public static void MoveAllMessagesToInbox()
        {
            SpamPage page = new SpamPage();
            page.WaitForPageToLoad();
            if (page.SelectAllMessages())
            {
                page.WaitForPageToLoad();
                page.BtnNotSpam.Click(7);
                page.WaitForPageToLoad();
            }
        }
    }
}
