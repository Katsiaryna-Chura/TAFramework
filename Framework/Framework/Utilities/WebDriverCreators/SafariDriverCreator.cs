﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;

namespace Framework.Core.Utilities.WebDriverCreators
{
    public class SafariDriverCreator
    {
        public IWebDriver CreateSafariDriver()
        {
            return new SafariDriver();
        }
    }
}
