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
        public Radio() { }
        public Radio(By by): base(by) { }
        public Radio(IWebElement el) : base(el) { }


        public void Select(int timeoutInSeconds)
        {
            WaitForElementToBeVisible(timeoutInSeconds);
            if (!Element.Selected)
                Element.Click();
        }

        public bool IsSelected()// ???
        {
            return Element.Selected;
        }
    }
}
