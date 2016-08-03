using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TAFramework.Steps;
using System.Threading;
using OpenQA.Selenium;

namespace FrameworkTests.Tests
{
    public class MarkingMessagesTests : BaseTest
    {
        [Test]
        public void Test11()
        {
            try
            {
                LoginPageSteps.LoginUser(TestsData.user1_email, TestsData.user1_password);
                BaseSteps.SendMessage(TestsData.user1_email, TestsData.subject, TestsData.message);
                InboxPageSteps.Refresh();
                InboxPageSteps.ReportMessageAsSpam(TestsData.user1_email, TestsData.subject);
                Assert.IsTrue(SpamPageSteps.IsMessagePresentInSpam(TestsData.user1_email, TestsData.subject), "The message isn't moved from inbox to spam, but it should be");
                SpamPageSteps.MoveMessageToInbox(TestsData.user1_email, TestsData.subject);
                Assert.IsTrue(InboxPageSteps.IsMessagePresentInInbox(TestsData.user1_email, TestsData.subject), "The message isn't moved from spam to inbox, but it should be");
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

        [Test]
        public void Test13()
        {
            try
            {
                LoginPageSteps.LoginUser(TestsData.user1_email, TestsData.user1_password);
                BaseSteps.SendMessage(TestsData.user1_email, TestsData.subject, TestsData.message);
                InboxPageSteps.Refresh();
                InboxPageSteps.MarkMessageAsStarred(TestsData.user1_email, TestsData.subject);
                Assert.IsTrue(InboxPageSteps.IsMessagePresentInStarredFolder(TestsData.user1_email, TestsData.subject), "The message isn't marked as starred, but it should be");
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
    }
}
