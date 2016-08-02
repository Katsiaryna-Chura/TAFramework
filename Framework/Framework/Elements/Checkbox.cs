using Framework.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Framework.Core.Elements
{
    public class Checkbox : BaseElement
    {
        public Checkbox() { }
        public Checkbox(By by) : base(by) { }
        public Checkbox(IWebElement el) : base(el) { }

        public void Select(int timeoutInSeconds)
        {
            WaitForElementToBeVisible(timeoutInSeconds);
            if (!Element.Selected)
                Element.Click();
        }

        public void Deselect(int timeoutInSeconds)
        {
            WaitForElementToBeVisible(timeoutInSeconds);
            if (Element.Selected)
                Element.Click();
        }
    }
}
