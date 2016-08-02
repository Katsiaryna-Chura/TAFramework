using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Framework.Core.Utilities.WebDriverCreators
{
    public class ChromeDriverCreator
    {
        public IWebDriver CreateChromeDriver()
        {
            return new ChromeDriver();
        }
    }
}
