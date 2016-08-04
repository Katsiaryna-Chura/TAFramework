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
        private static IWebDriver driver = null;// new WebDriverCreator().CreateDriver();

        private WebDriver() { }

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void CloseWebDriver()
        {
            driver.Close();

        }

        public static void CreateWebDriver()
        {
            driver = new WebDriverCreator().CreateDriver();
        }
    }
}
