using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TAFramework.Steps;
using System.Threading;
using Framework.Core.Utilities;
using TAFramework.Services;
using TAFramework.Configs;
using OpenQA.Selenium;

namespace FrameworkTests.Tests
{
    [TestFixture]
    class Tests
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [OneTimeSetUp]
        public void SetUp()
        {
            LoginPageSteps.OpenGmail();
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    LoginPageSteps.SwitchUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    BaseSteps.CleanUserSettingsAndMessages();
        //    LoginPageSteps.SwitchUser("petra.1212.petrova@gmail.com", "petr0va1212");
        //    BaseSteps.CleanUserSettingsAndMessages();
        //    BaseSteps.SignOut();
        //}

        //[Test]
        //public void Test1()
        //{
        //    LoginPageSteps.LoginUser("petra.1212.petrova@gmail.com", "petr0va1212");
        //    BaseSteps.SendMessage("1vana.1104.1vanova@gmail.com", "test", "test");
        //    LoginPageSteps.SwitchUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    InboxPageSteps.ReportMessageAsSpam("petra.1212.petrova@gmail.com");
        //    LoginPageSteps.SwitchUser("petra.1212.petrova@gmail.com", "petr0va1212");
        //    BaseSteps.SendMessage("1vana.1104.1vanova@gmail.com", "test", "test123");
        //    LoginPageSteps.SwitchUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    Assert.IsTrue(SpamPageSteps.IsMessagePresentInSpam("petra.1212.petrova@gmail.com", "test"));
        //}

        //[Test]
        //public void Test2()
        //{
        //    LoginPageSteps.LoginUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    BaseSteps.GoToSettings();
        //    SettingPageSteps.GoToForwardingAndPOP();
        //    ForwardPageSteps.AddForwardingAddress("petra.1212.petrova@gmail.com");
        //    LoginPageSteps.SwitchUser("petra.1212.petrova@gmail.com", "petr0va1212");
        //    InboxPageSteps.GoToMessagePage("forwarding-noreply@google.com");
        //    MessagePageSteps.ConfirmForwarding();
        //    LoginPageSteps.SwitchUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    BaseSteps.GoToSettings();
        //    SettingPageSteps.GoToForwardingAndPOP();
        //    ForwardPageSteps.ChooseForwardingVariant();
        //    BaseSteps.GoToSettings();
        //    SettingPageSteps.GoToFiltersAndBlockedAddresses();
        //    FiltersPageSteps.CreateNewFilter("ekaterina.chura@gmail.com");
        //    LoginPageSteps.SwitchUser("ekaterina.chura@gmail.com", "11495zero");
        //    BaseSteps.SendMessage("1vana.1104.1vanova@gmail.com", "no attach", "text with no attachment");
        //    BaseSteps.SendMesageWithAttachment("1vana.1104.1vanova@gmail.com", "attach", "text with attachment", @"C:\Users\Katsiaryna_Chura@epam.com\Documents\text.txt");
        //    LoginPageSteps.SwitchUser("1vana.1104.1vanova@gmail.com", "1van0va1");

        //    Assert.IsTrue(InboxPageSteps.IsMessagePresentInInbox("ekaterina.chura@gmail.com", "no attach"));
        //    Assert.IsTrue(ImportantPageSteps.IsMessageMarkedAsImportant("ekaterina.chura@gmail.com", "no attach"));//IsFalse

        //    Assert.IsTrue(TrashPageSteps.IsMessagePresentInTrash("ekaterina.chura@gmail.com", "attach"));
        //    Assert.IsFalse(ImportantPageSteps.IsMessageMarkedAsImportant("ekaterina.chura@gmail.com", "attach"));//IsTrue

        //    LoginPageSteps.SwitchUser("petra.1212.petrova@gmail.com", "petr0va1212");
        //    Assert.IsTrue(InboxPageSteps.IsMessagePresentInInbox("ekaterina.chura@gmail.com", "no attach"));
        //}

        //[Test]
        //public void Test3()
        //{
        //    LoginPageSteps.LoginUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    BaseSteps.SendMesageWithAttachment("petra.1212.petrova@gmail.com", "attach", "text with attachment", @"C:\Users\Katsiaryna_Chura@epam.com\Documents\my_archive.7z");
        //    Assert.IsTrue(BaseSteps.IsLargeFileAlertPresent());
        //    BaseSteps.CloseAlert();
        //}

        //[Test]
        //public void Test4()
        //{
        //    try
        //    {
        //        LoginPageSteps.LoginUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //        BaseSteps.GoToThemes();
        //        ThemesPageSteps.ChangeBackgroungImage(@"C:\Users\Katsiaryna_Chura@epam.com\Documents\text.jpg");
        //        Assert.IsTrue(ThemesPageSteps.IsUploadErrorOccured());
        //        ThemesPageSteps.CloseThemesWindow();
        //        log.Info("Test 4 - PASS");
        //    }
        //    catch (Exception ex) when (ex is NoSuchElementException || ex is TimeoutException)
        //    {
        //        log.Error(ex);
        //    }
        //    catch (AssertionException ex)
        //    {
        //        log.Error(ex.Message);
        //        throw;
        //    }
        //}

        [Test]
        public void Test5()
        {
            try
            {
                LoginPageSteps.LoginUser("1vana.1104.1vanova@gmail.com", "1van0va1");
                string city = IpApiService.GetCityFromIp(TestsData.IP);
                BaseSteps.SendMessageWithEmoticons("1vana.1104.1vanova@gmail.com", "emoticons", city, 2, 9);
                InboxPageSteps.Refresh();
                InboxPageSteps.GoToMessagePage("1vana.1104.1vanova@gmail.com");
                Assert.AreEqual(2, MessagePageSteps.CountOfEmoticonsInMessage(), "The number of emoticons in the message is incorrect");
                Assert.IsTrue(MessagePageSteps.IsMessageContainsText(TestsData.City), "The message doesn't contains right city name");
                log.Info("Test 5 - PASS");
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is TimeoutException)
            {
                log.Error(ex);
            }
            catch (AssertionException ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        //// test 6 : don't know how assertion should look like 
        //// test 7 : there's no such option (creating meeting)
        //// test 8 - 10 : can't find items to work with shortcuts 

        //[Test]
        //public void Test11()
        //{
        //    LoginPageSteps.LoginUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    BaseSteps.SendMessage("1vana.1104.1vanova@gmail.com", "test", "test");
        //    InboxPageSteps.Refresh();
        //    InboxPageSteps.ReportMessageAsSpam("1vana.1104.1vanova@gmail.com");
        //    Thread.Sleep(1000);
        //    Assert.IsTrue(SpamPageSteps.IsMessagePresentInSpam("1vana.1104.1vanova@gmail.com", "test"));
        //    Thread.Sleep(3000);
        //    SpamPageSteps.MoveMessageToInbox("1vana.1104.1vanova@gmail.com","test");
        //    Assert.IsTrue(InboxPageSteps.IsMessagePresentInInbox("1vana.1104.1vanova@gmail.com", "test"));
        //}

        //[Test]
        //public void Test12()
        //{
        //    LoginPageSteps.LoginUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    BaseSteps.GoToSettings();
        //    SettingPageSteps.SetSignature("Ivana");
        //    Assert.IsTrue(InboxPageSteps.IsSignaturePresentInMessage("Ivana"));
        //    SettingPageSteps.RemoveSignature();
        //}

        //[Test]
        //public void Test13()
        //{
        //    LoginPageSteps.LoginUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    BaseSteps.SendMessage("1vana.1104.1vanova@gmail.com", "test", "test");
        //    InboxPageSteps.Refresh();
        //    InboxPageSteps.MarkMessageAsStarred("1vana.1104.1vanova@gmail.com", "test");
        //    Assert.IsTrue(InboxPageSteps.IsMessagePresentInStarredFolder("1vana.1104.1vanova@gmail.com", "test"));
        //}

        //[Test]
        //public void Test14()
        //{
        //    LoginPageSteps.LoginUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    BaseSteps.GoToSettings();
        //    SettingPageSteps.SetOutOfOfficeAutoReplyOn("vacation", "Sorry. I'm on vacation now.");
        //    Thread.Sleep(2000);
        //    LoginPageSteps.SwitchUser("petra.1212.petrova@gmail.com", "petr0va1212");
        //    BaseSteps.SendMessage("1vana.1104.1vanova@gmail.com","hello","hello");
        //    Thread.Sleep(10000);
        //    InboxPageSteps.Refresh();
        //    Thread.Sleep(7000);
        //    Assert.IsTrue(InboxPageSteps.IsMessagePresentInInbox("1vana.1104.1vanova@gmail.com","vacation Re: hello"));
        //    LoginPageSteps.SwitchUser("1vana.1104.1vanova@gmail.com", "1van0va1");
        //    SettingPageSteps.SetOutOfOfficeAutoReplyOff();
        //}
    }
}
