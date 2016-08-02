using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Framework.Core.Utilities.WebDriverCreators
{
    public class FirefoxDriverCreator
    {
        public IWebDriver CreateFirefoxDriver()
        {
            return new FirefoxDriver();
        }
    }
}
