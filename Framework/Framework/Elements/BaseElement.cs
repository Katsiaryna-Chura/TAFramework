using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Framework.Core.Utilities;
using Framework.Core.Extensions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Framework.Core.Elements
{
    public class BaseElement
    {
        public By By { get; set; }
        public string Name { get; set; }

        protected static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IWebElement Element
        {
            get
            {
                return WebDriver.GetDriver().FindElement(this.By);
            }
            protected set { Element = value; }
        }

        public BaseElement(string name)
        {
            this.Name = name;
        }

        public BaseElement(By by, string name)
        {
            this.By = by;
            this.Name = name;
        }

        public BaseElement(IWebElement element, string name)
        {
            this.Element = element;
            this.Name = name;
        }

        public void WaitForElementToBeVisible(int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.GetDriver(), TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(this.By));
        }

        public void WaitForElementToBeClickable(int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.GetDriver(), TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(this.By));
        }

        public bool IsElementPresentOnPage(int timeoutInSeconds)
        {
            try
            {
                WebDriver.GetDriver().FindElement(this.By, timeoutInSeconds);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
