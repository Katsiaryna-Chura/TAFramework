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
        public Checkbox(string name) : base(name) { }
        public Checkbox(By by, string name) : base(by, name) { }
        public Checkbox(IWebElement el, string name) : base(el, name) { }

        public void Select(int timeoutInSeconds)
        {
            WaitForElementToBeVisible(timeoutInSeconds);
            if (!Element.Selected)
            {
                Element.Click();
                log.Info($"{this.Name} was selected");
            }
        }

        public void Deselect(int timeoutInSeconds)
        {
            WaitForElementToBeVisible(timeoutInSeconds);
            if (Element.Selected)
            {
                Element.Click();
                log.Info($"{this.Name} was deselected");
            }
        }
    }
}
