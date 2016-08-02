using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Utilities;

namespace Framework.Core.Pages
{
    public class AbstractPage
    {
        public string URL { get; protected set; }

        public void GoToPage()
        {
            WebDriver.GetDriver().Navigate().GoToUrl(this.URL);
        }
    }
}
