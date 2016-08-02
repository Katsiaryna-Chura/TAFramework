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

        public IWebElement Element {
            get
            {
                return WebDriver.GetDriver().FindElement(this.By);//with timeout
            }
            protected set { Element = value; }
        }

        public BaseElement(){ }

        public BaseElement(By by)
        {
            this.By = by;
        }

        public BaseElement(IWebElement element)
        {
            this.Element = element;
        }
        //protected readonly int timeout = 7;

        //public bool IsDisplayed()
        //{
        //    return WebDriver.GetDriver().FindElement(by, timeout).Displayed;
        //}

        //public bool IsEnabled()
        //{
        //    return WebDriver.GetDriver().FindElement(by, timeout).Enabled;
        //}

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
            catch (/*NoSuchElement*/Exception)
            {
                return false;
            }
        }
    }
}
