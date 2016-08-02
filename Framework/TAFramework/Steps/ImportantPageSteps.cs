using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class ImportantPageSteps
    {
        public static void GoToImportantFolder()
        {
            BasePage page = new BasePage();
            page.TxtSearchText.TypeText("is:important",7);
            page.BtnSearch.Click(7);
        }

        public static bool IsMessageMarkedAsImportant(string email, string subject)
        {
            ImportantPage page = new ImportantPage();
            GoToImportantFolder();
            page.WaitForPageToLoad();
            return page.IsMessageExists(email, subject, 7);
        }
    }
}
