using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TAFramework.Steps;

namespace FrameworkTests.Tests
{
    public class BaseTest
    {
        protected static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [OneTimeSetUp]
        public void SetUp()
        {
            LoginPageSteps.OpenGmail();
        }

        [TearDown]
        public void TearDown()
        {
            LoginPageSteps.SwitchUser(TestsData.user1_email, TestsData.user1_password);
            BaseSteps.CleanUserSettingsAndMessages();
            LoginPageSteps.SwitchUser(TestsData.user2_email, TestsData.user2_password);
            BaseSteps.CleanUserSettingsAndMessages();
            BaseSteps.SignOut();
        }
    }
}
