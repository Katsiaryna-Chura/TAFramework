using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;

namespace Framework.Core.Utilities.WebDriverCreators
{
    public class IEDriverCreator
    {
        public IWebDriver CreateIEDriver()
        {
            return new InternetExplorerDriver();
        }
    }
}
