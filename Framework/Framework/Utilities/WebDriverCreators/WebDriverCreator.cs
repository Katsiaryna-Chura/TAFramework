using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Framework.Core.Utilities.WebDriverCreators;

namespace Framework.Core.Utilities
{
    public class WebDriverCreator
    {
        public IWebDriver CreateDriver()
        {
            string browser = ConfigReader.GetBrowser();

            switch (browser)
            {
                case "Firefox":
                    return new FirefoxDriverCreator().CreateFirefoxDriver();
                case "Chrome":
                    return new ChromeDriverCreator().CreateChromeDriver();
                case "IE":
                    return new IEDriverCreator().CreateIEDriver();
                case "Opera":
                    return new OperaDriverCreator().CreateOperaDriver();
                case "Safari":
                    return new SafariDriverCreator().CreateSafariDriver();
                default:
                    return new FirefoxDriverCreator().CreateFirefoxDriver();
            }
        }
    }
}
