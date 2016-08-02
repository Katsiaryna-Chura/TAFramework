using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class InboxPageSteps
    {
        public static void ReportMessageAsSpam(string email)
        {
            InboxPage page = new InboxPage();
            page.CheckMessageChecker(email, 7);
            page.BtnReportSpam.Click(7);
        }

        public static void GoToMessagePage(string email)// add subject as parameter ?
        {
            InboxPage page = new InboxPage();
            page.GoToMessagePage(email, 10);
        }

        public static bool IsMessagePresentInInbox(string email, string subject)
        {
            InboxPage page = new InboxPage();
            page.GoToPage();
            page.WaitForPageToLoad();
            return page.IsMessageExists(email, subject, 7);
        }

        public static void CleanInbox()
        {
            InboxPage page = new InboxPage();
            page.GoToPage();
            page.WaitForPageToLoad();
            if (page.SelectAllMessages())
            {
                //page.WaitForPageToLoad();
                page.BtnDelete.Click(5);
                page.WaitForPageToLoad();
            }
        }

        public static void Refresh()
        {
            InboxPage page = new InboxPage();
            page.BtnRefresh.Click(5);
        }

        public static bool IsSignaturePresentInMessage(string signature)
        {
            InboxPage page = new InboxPage();
            page.BbtnCompose.Click(7);
            bool result = signature.Equals(page.LblSignature.GetText(7));
            page.BtnCloseMessage.Click(5);
            return result;
        }

        public static void MarkMessageAsStarred(string email, string subject)
        {
            InboxPage page = new InboxPage();
            page.MarkMessageAsStarred(email,subject);
        }

        public static bool IsMessagePresentInStarredFolder(string email, string subject)// to another class ?
        {
            InboxPage page = new InboxPage();
            page.linkStarred.Click(5);
            return page.IsMessageExists(email,subject,7);
        }
    }
}
