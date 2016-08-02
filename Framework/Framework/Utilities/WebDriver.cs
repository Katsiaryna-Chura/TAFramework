using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Framework.Core.Utilities
{
    public class WebDriver
    {
        private static IWebDriver driver = new WebDriverCreator().CreateDriver();

        private WebDriver() { }

        public static IWebDriver GetDriver()
        {
            return driver;
        }
    }
}
