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
        public Button(string name) : base(name) { }
        public Button(By by, string name) : base(by, name) {}
        public Button(IWebElement el, string name) : base(el, name) { }

        public void Click(int timeoutInSeconds)
        {
            WaitForElementToBeClickable(timeoutInSeconds);
            this.Element.Click();
            log.Info($"{this.Name} was clicked");
        }
    }
}
