using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TAFramework.Steps;
using Framework.Core.Utilities;

namespace FrameworkTests.Tests
{
    public class BaseTest
    {
        protected static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [SetUp]
        public void SetUp()
        {
            WebDriver.CreateWebDriver();
            LoginPageSteps.OpenGmail();
            log.Info($"Test {TestContext.CurrentContext.Test.Name} started.");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                log.Info("TearDown started");
                LoginPageSteps.SwitchUser(TestsData.user1_email, TestsData.user1_password);
                BaseSteps.CleanUserSettingsAndMessages();
                LoginPageSteps.SwitchUser(TestsData.user2_email, TestsData.user2_password);
                BaseSteps.CleanUserSettingsAndMessages();
                BaseSteps.SignOut();
            }
            catch (Exception)
            {
                log.Error("Error occured in TearDown");
            }
            finally
            {
                WebDriver.CloseWebDriver();
                log.Info("TearDown finished");
            }
        }
    }
}
