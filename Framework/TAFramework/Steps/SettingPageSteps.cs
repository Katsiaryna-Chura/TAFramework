using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class SettingPageSteps
    {
        public static void OpenSettings()
        {
            SettingsPage page = new SettingsPage();
            page.GoToPage();
        }

        public static void GoToForwardingAndPOP()
        {
            SettingsPage page = new SettingsPage();
            page.LinkForwardingAndPOP.Click(7);
        }

        public static void GoToFiltersAndBlockedAddresses()
        {
            SettingsPage page = new SettingsPage();
            page.LlinkFiltersAndBlockedAddresses.Click(7);
        }

        public static void OpenThemes()
        {
            SettingsPage page = new SettingsPage();
            page.GoToPage();
            page.LinkThemes.Click(7);
        }

        public static void SetSignature(string signature)
        {
            SettingsPage page = new SettingsPage();
            page.TxtSignature.TypeText(signature, 7);
            page.WaitForPageToLoad();
            page.BtnSaveChanges.Click(7);
            page.WaitForPageToLoad();
        }

        public static void RemoveSignature()
        {
            SettingsPage page = new SettingsPage();
            page.GoToPage();
            page.WaitForPageToLoad();
            if (!page.RbNoSignature.IsSelected())
            {
                page.RbNoSignature.Select(5);
                page.BtnSaveChanges.Click(5);
            }
        }

        public static void SetOutOfOfficeAutoReplyOn(string subject, string message)
        {
            SettingsPage page = new SettingsPage();
            page.WaitForPageToLoad();
            page.RbAutoReplyOn.Select(5);
            page.TxtAutoReplySubject.TypeText(subject, 5);
            page.TxtAutoReplyMessage.TypeText(message, 5);
            page.WaitForPageToLoad();
            page.BtnSaveChanges.Click(5);
            page.WaitForPageToLoad();
        }

        public static void SetOutOfOfficeAutoReplyOff()
        {
            SettingsPage page = new SettingsPage();
            page.GoToPage();
            page.WaitForPageToLoad();
            page.WaitForPageToLoad();
            if (!page.RbAutoReplyOff.IsSelected())
            {
                page.RbAutoReplyOff.Select(5);
                page.WaitForPageToLoad();
                page.BtnSaveChanges.Click(5);
                page.WaitForPageToLoad();
            }
        }
    }
}
