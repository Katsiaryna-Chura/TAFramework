using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class MessagePageSteps
    {
        public static void ReportMessageAsSpam()
        {
            MessagePage page = new MessagePage();
            page.BtnReportSpam.Click(7);
        }

        public static void ConfirmForwarding()
        {
            MessagePage page = new MessagePage();
            page.LinkGoToConfirmation.Click(7);
            page.ClickConfirm(7);
        }

        public static int CountOfEmoticonsInMessage()
        {
            MessagePage page = new MessagePage();
            return page.GetNumberOfEmoticonsInMessage(5);
        }

        public static bool IsMessageContainsText(string text)
        {
            MessagePage page = new MessagePage();
            return page.LblMessageBody.GetText(5).Contains(text);
        }
    }
}
