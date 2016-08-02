using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class FiltersPageSteps
    {
        public static void GoToFiltersPage()
        {
            FiltersPage page = new FiltersPage();
            page.GoToPage();
        }

        public static void CreateNewFilter(string email)
        {
            FiltersPage page = new FiltersPage();
            page.BtnCreateNewFilter.Click(7);
            page.TxtFrom.TypeText(email, 7);
            page.CbHasAttachment.Select(7);
            page.LinkCreateFilterWithThisSearch.Click(7);
            page.CbMarkAsImportant.Select(7);
            page.CbDeleteIt.Select(7);
            page.BtnConfirmCreation.Click(7);
        }

        public static void DeleteAllFilters()
        {
            GoToFiltersPage();
            FiltersPage page = new FiltersPage();
            page.BtnSelectAll.Click(5);
            if (page.BtnDelete.Element.Enabled)
            {
                page.BtnDelete.Click(5);
                page.BtnOk.Click(5);
            }
        }
    }
}
