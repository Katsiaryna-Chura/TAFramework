using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium;

namespace Framework.Core.Utilities.WebDriverCreators
{
    public class OperaDriverCreator
    {
        public IWebDriver CreateOperaDriver()
        {
            return new OperaDriver();
        }
    }
}
