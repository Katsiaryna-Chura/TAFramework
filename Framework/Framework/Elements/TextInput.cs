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
        public TextInput(string name) : base(name) { }
        public TextInput(By by, string name) : base(by, name) { }
        public TextInput(IWebElement el, string name) : base(el, name) { }

        public void TypeText(string text, int timeoutInSeconds)
        {
            WaitForElementToBeVisible(timeoutInSeconds);
            Element.Clear();
            Element.SendKeys(text);
            log.Info($"Text was entered to {this.Name}");
        }

        public string GetText()
        {
            return Element.Text;
        }
    }
}
