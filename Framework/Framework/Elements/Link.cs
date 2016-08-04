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
        public Link(string name) : base(name) { }
        public Link(By by, string name) : base(by, name) { }
        public Link(IWebElement el, string name) : base(el, name) { }


        public void Click(int timeoutInSeconds)
        {
            WaitForElementToBeClickable(timeoutInSeconds);
            Element.Click();
            log.Info($"{this.Name} was clicked");
        }
    }
}
