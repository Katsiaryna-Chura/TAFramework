using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Utilities;
using OpenQA.Selenium;

namespace Framework.Core.Elements
{
    public class Label:BaseElement
    {
        public Label(string name) : base(name) { }
        public Label(By by, string name) : base(by, name) { }
        public Label(IWebElement el, string name) : base(el, name) { }

        public string GetText(int timeoutInSeconds)
        {
            WaitForElementToBeVisible(timeoutInSeconds);
            return Element.Text;
        }
    }
}
