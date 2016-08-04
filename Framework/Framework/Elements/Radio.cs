using Framework.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Framework.Core.Elements
{
    public class Radio : BaseElement
    {
        public Radio(string name) : base(name) { }
        public Radio(By by, string name) : base(by, name) { }
        public Radio(IWebElement el, string name) : base(el, name) { }


        public void Select(int timeoutInSeconds)
        {
            WaitForElementToBeVisible(timeoutInSeconds);
            if (!Element.Selected)
            {
                Element.Click();
                log.Info($"{this.Name} was selected");
            }
        }

        public bool IsSelected()
        {
            return Element.Selected;
        }
    }
}
