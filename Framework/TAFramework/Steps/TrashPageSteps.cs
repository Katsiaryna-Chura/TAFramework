using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class TrashPageSteps
    {
        //public static void GoToTrashFolder()
        //{
        //    TrashPage page = new TrashPage();
        //    page.GoToPage();
        //}

        public static bool IsMessagePresentInTrash(string email, string subject)
        {
            TrashPage page = new TrashPage();
            page.WaitForPageToLoad();
            return page.IsMessageExists(email, subject, 7);
        }

        public static void CleanTrash()
        {
            TrashPage page = new TrashPage();
            page.WaitForPageToLoad();
            if (page.SelectAllMessages())
            {
                page.WaitForPageToLoad();
                page.BtnDeleteForever.Click(7);
                page.WaitForPageToLoad();
            }
            //if (page.BtnCleanTrash.IsElementPresentOnPage(5))
            //{
            //    page.BtnCleanTrash.Click(7);
            //    page.WaitForPageToLoad();
            //    page.BtnOk.Click(7);
            //    page.WaitForPageToLoad();
            //}
        }
    }
}
