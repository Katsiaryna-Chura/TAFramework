using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TAFramework.Steps;
using OpenQA.Selenium;
using TAFramework.Services;

namespace FrameworkTests.Tests
{
    public class SendingMessagesTests : BaseTest
    {
        //[Test]
        //public void Test1()
        //{
        //    try
        //    {
        //        LoginPageSteps.LoginUser(TestsData.user2_email, TestsData.user2_password);
        //        BaseSteps.SendMessage(TestsData.user1_email, TestsData.subject, TestsData.message);
        //        LoginPageSteps.SwitchUser(TestsData.user1_email, TestsData.user1_password);
        //        InboxPageSteps.ReportMessageAsSpam(TestsData.user2_email, TestsData.subject);
        //        LoginPageSteps.SwitchUser(TestsData.user2_email, TestsData.user2_password);
        //        BaseSteps.SendMessage(TestsData.user1_email, TestsData.subject2, TestsData.message2);
        //        LoginPageSteps.SwitchUser(TestsData.user1_email, TestsData.user1_password);
        //        Assert.IsTrue(SpamPageSteps.IsMessagePresentInSpam(TestsData.user2_email, TestsData.subject2), "Second message isn't in spam, but it should be");
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
        public void Test3()
        {
            try
            {
                string path = $@"{TestContext.CurrentContext.TestDirectory}\{TestsData.big_attach_file_path}";
                LoginPageSteps.LoginUser(TestsData.user1_email, TestsData.user1_password);
                BaseSteps.SendMesageWithAttachment(TestsData.user2_email, TestsData.attach_subject, TestsData.attach_message, path);
                Assert.IsTrue(BaseSteps.IsLargeFileAlertPresent(), "Large file alert isn't present, but it should be");
                log.Info($"{TestContext.CurrentContext.Test.Name} - {TestsData.Pass}");
                BaseSteps.CloseAlert();
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

        //[Test]
        //public void Test5()
        //{
        //    try
        //    {
        //        LoginPageSteps.LoginUser(TestsData.user1_email, TestsData.user1_password);
        //        string city = IpApiService.GetCityFromIp(TestsData.IP);
        //        BaseSteps.SendMessageWithEmoticons(TestsData.user1_email, TestsData.emoticon_subject, city,
        //            int.Parse(TestsData.emoticon_number_1), int.Parse(TestsData.emoticon_number_2));
        //        InboxPageSteps.Refresh();
        //        InboxPageSteps.GoToMessagePage(TestsData.user1_email, TestsData.emoticon_subject);
        //        Assert.AreEqual(2, MessagePageSteps.CountOfEmoticonsInMessage(), "The number of emoticons in the message is incorrect");
        //        Assert.IsTrue(MessagePageSteps.IsMessageContainsText(TestsData.City), "The message doesn't contains right city name");
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
    }
}
