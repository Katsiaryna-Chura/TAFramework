using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Utilities;
using OpenQA.Selenium;

namespace Framework.Core.Elements
{
    public class Button : BaseElement
    {
        public Button() { }
        public Button(By by): base(by) {}
        public Button(IWebElement el) : base(el) { }

        public void Click(int timeoutInSeconds)
        {
            WaitForElementToBeClickable(timeoutInSeconds);
            this.Element.Click();
        }
    }
}
