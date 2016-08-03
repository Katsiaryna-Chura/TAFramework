using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class BaseSteps
    {
        public static void SignOut()
        {
            BasePage page = new BasePage();
            page.WaitForPageToLoad();
            page.BtnAccount.Click(7);
            page.BtnSignOut.Click(7);
        }

        public static void GoToSettings()
        {
            BasePage page = new BasePage();
            page.BtnAllSettings.Click(10);
            SettingPageSteps.OpenSettings();
        }

        public static void GoToThemes()
        {
            BasePage page = new BasePage();
            page.BtnAllSettings.Click(10);
            SettingPageSteps.OpenThemes();
        }

        public static void SendMessage(string email, string subject, string message)
        {
            BasePage page = new BasePage();
            page.BbtnCompose.Click(7);
            page.TxtTo.TypeText(email, 7);
            page.TxtSubject.TypeText(subject, 7);
            page.TxtMessage.TypeText(message, 7);
            page.BtnSend.Click(7);
        }

        public static void SendMessageWithEmoticons(string email, string subject, string message, int emoticonNum1, int emoticonNum2)
        {
            BasePage page = new BasePage();
            page.BbtnCompose.Click(7);
            page.TxtTo.TypeText(email, 7);
            page.TxtSubject.TypeText(subject, 7);
            page.TxtMessage.TypeText(message, 7);
            page.BtnInsertEmoticon.Click(5);
            page.BtnShowFaceEmoticons.Click(5);
            page.AddEmoticonsToMessage(emoticonNum1, emoticonNum2);
            page.BtnSend.Click(7);
        }

        public static void SendMesageWithAttachment(string email, string subject, string message, string filepath)
        {
            BasePage page = new BasePage();
            page.BbtnCompose.Click(7);
            page.TxtTo.TypeText(email, 7);
            page.TxtSubject.TypeText(subject, 7);
            page.TxtMessage.TypeText(message, 7);
            page.BtnAttachFile.Click(7);
            if (!page.AttachSpecifiedFile(filepath))
                return;
            page.BtnSend.Click(7);

        }

        public static bool IsLargeFileAlertPresent()
        {
            BasePage page = new BasePage();
            return page.Alert.IsElementPresentOnPage(3);
        }

        public static void CloseAlert()
        {
            BasePage page = new BasePage();
            page.WaitForPageToLoad();
            if (page.BtnCloseAlert.IsElementPresentOnPage(5))
                page.BtnCloseAlert.Click(5);
            page.WaitForPageToLoad();
        }

        public static void CleanUserSettingsAndMessages()
        {
            SpamPageSteps.MoveAllMessagesToInbox();
            InboxPageSteps.CleanInbox();
            TrashPageSteps.CleanTrash();
            FiltersPageSteps.DeleteAllFilters();
            ForwardPageSteps.DeleteAllForwardingAddresses();
        }

        public static void WaitForReply()
        {
            BasePage page = new BasePage();
            page.WaitForReplyMessageToBeDelivered();
        }
    }
}
