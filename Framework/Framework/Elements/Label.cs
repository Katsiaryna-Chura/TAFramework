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
        public Label() { }
        public Label(By by) : base(by) { }
        public Label(IWebElement el) : base(el) { }

        public string GetText(int timeoutInSeconds)
        {
            WaitForElementToBeVisible(timeoutInSeconds);
            return Element.Text;
        }
    }
}
