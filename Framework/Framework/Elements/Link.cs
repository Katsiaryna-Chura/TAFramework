using Framework.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Framework.Core.Elements
{
    public class Link:BaseElement
    {
        public Link() { }
        public Link(By by) : base(by) { }
        public Link(IWebElement el) : base(el) { }


        public void Click(int timeoutInSeconds)
        {
            WaitForElementToBeClickable(timeoutInSeconds);
            Element.Click();
        }
    }
}
