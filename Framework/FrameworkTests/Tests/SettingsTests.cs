using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TAFramework.Steps;
using OpenQA.Selenium;

namespace FrameworkTests.Tests
{
    public class SettingsTests : BaseTest
    {
        //[Test]
        //public void Test2()
        //{
        //    try
        //    {
        //        string path = $@"{TestContext.CurrentContext.TestDirectory}\{TestsData.normal_attach_file}";
        //        LoginPageSteps.LoginUser(TestsData.user1_email, TestsData.user1_password);
        //        BaseSteps.GoToSettings();
        //        SettingPageSteps.GoToForwardingAndPOP();
        //        ForwardPageSteps.AddForwardingAddress(TestsData.user2_email);
        //        LoginPageSteps.SwitchUser(TestsData.user2_email, TestsData.user2_password);
        //        InboxPageSteps.GoToMessagePage(TestsData.google_forwarding_email);
        //        MessagePageSteps.ConfirmForwarding();
        //        LoginPageSteps.SwitchUser(TestsData.user1_email, TestsData.user1_password);
        //        BaseSteps.GoToSettings();
        //        SettingPageSteps.GoToForwardingAndPOP();
        //        ForwardPageSteps.ChooseForwardingVariant();
        //        BaseSteps.GoToSettings();
        //        SettingPageSteps.GoToFiltersAndBlockedAddresses();
        //        FiltersPageSteps.CreateNewFilter(TestsData.user3_email);
        //        LoginPageSteps.SwitchUser(TestsData.user3_email, TestsData.user3_password);
        //        BaseSteps.SendMessage(TestsData.user1_email, TestsData.no_attach_subject, TestsData.no_attach_message);
        //        BaseSteps.SendMesageWithAttachment(TestsData.user1_email, TestsData.attach_subject, TestsData.attach_message, path);
        //        LoginPageSteps.SwitchUser(TestsData.user1_email, TestsData.user1_password);

        //        Assert.IsTrue(InboxPageSteps.IsMessagePresentInInbox(TestsData.user3_email, TestsData.no_attach_subject));
        //        Assert.IsTrue(ImportantPageSteps.IsMessageMarkedAsImportant(TestsData.user3_email, TestsData.no_attach_subject));//IsFalse

        //        Assert.IsTrue(TrashPageSteps.IsMessagePresentInTrash(TestsData.user3_email, TestsData.attach_subject));
        //        Assert.IsFalse(ImportantPageSteps.IsMessageMarkedAsImportant(TestsData.user3_email, TestsData.attach_subject));//IsTrue

        //        LoginPageSteps.SwitchUser(TestsData.user2_email, TestsData.user2_password);
        //        Assert.IsTrue(InboxPageSteps.IsMessagePresentInInbox(TestsData.user3_email, TestsData.no_attach_subject));
        //        log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Pass}");
        //    }
        //    catch (Exception ex) when (ex is NoSuchElementException || ex is TimeoutException)
        //    {
        //        log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Failed}");
        //        log.Error(ex);
        //    }
        //    catch (AssertionException ex)
        //    {
        //        log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Failed}");
        //        log.Error(ex.Message);
        //        throw;
        //    }
        //}

        [Test]
        public void Test4()
        {
            try
            {
                string path = $@"{TestContext.CurrentContext.TestDirectory}\{TestsData.not_image_file}";
                LoginPageSteps.LoginUser(TestsData.user1_email, TestsData.user1_password);
                BaseSteps.GoToThemes();
                ThemesPageSteps.ChangeBackgroungImage(path);
                Assert.IsTrue(ThemesPageSteps.IsUploadErrorOccured(), "Upload error hasn't occured, but it should have");
                ThemesPageSteps.CloseThemesWindow();
                log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Pass}");
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is TimeoutException)
            {
                log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Failed}");
                log.Error(ex);
            }
            catch (AssertionException ex)
            {
                log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Failed}");
                log.Error(ex.Message);
                throw;
            }
        }

        [Test]
        public void Test12()
        {
            try
            {
                LoginPageSteps.LoginUser(TestsData.user1_email, TestsData.user1_password);
                BaseSteps.GoToSettings();
                SettingPageSteps.SetSignature(TestsData.signature);
                Assert.IsTrue(InboxPageSteps.IsSignaturePresentInMessage(TestsData.signature), "The signature isn't present, but it should be");
                log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Pass}");
                SettingPageSteps.RemoveSignature();
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is TimeoutException)
            {
                log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Failed}");
                log.Error(ex);
            }
            catch (AssertionException ex)
            {
                log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Failed}");
                log.Error(ex.Message);
                throw;
            }
        }

        [Test]
        public void Test14()
        {
            try
            {
                LoginPageSteps.LoginUser(TestsData.user1_email, TestsData.user1_password);
                BaseSteps.GoToSettings();
                SettingPageSteps.SetOutOfOfficeAutoReplyOn(TestsData.vacation_subject, TestsData.vacation_message);
                LoginPageSteps.SwitchUser(TestsData.user2_email, TestsData.user2_password);
                BaseSteps.SendMessage(TestsData.user1_email, TestsData.subject, TestsData.message);
                BaseSteps.WaitForReply();
                InboxPageSteps.Refresh();
                Assert.IsTrue(InboxPageSteps.IsMessagePresentInInbox(TestsData.user1_email,
                    $"{TestsData.vacation_subject} {TestsData.Re} {TestsData.subject}"), "Correct reply message isn't present in inbox, but it should be");
                log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Pass}");
                LoginPageSteps.SwitchUser(TestsData.user1_email, TestsData.user1_password);
                SettingPageSteps.SetOutOfOfficeAutoReplyOff();
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is TimeoutException)
            {
                log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Failed}");
                log.Error(ex);
            }
            catch (AssertionException ex)
            {
                log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Failed}");
                log.Error(ex.Message);
                throw;
            }
        }
    }
}
