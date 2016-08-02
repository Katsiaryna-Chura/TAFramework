using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Utilities;
using OpenQA.Selenium;

namespace Framework.Core.Elements
{
    public class TextInput : BaseElement
    {
        public TextInput() { }
        public TextInput(By by): base(by) { }
        public TextInput(IWebElement el) : base(el) { }

        public void TypeText(string text, int timeoutInSeconds)
        {
            WaitForElementToBeVisible(timeoutInSeconds);
            Element.Clear();
            Element.SendKeys(text);
        }

        public string GetText()
        {
            return Element.Text;
        }
    }
}
