using Framework.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TAFramework.Pages;

namespace TAFramework.Steps
{
    public class ThemesPageSteps
    {
        public static void ChangeBackgroungImage(string imagePath)
        {
            ThemesPage page = new ThemesPage();
            page.LinkSetTheme.Click(5);
            Thread.Sleep(3000);
            page.BtnMyPhotos.Click(5);
            Thread.Sleep(3000);
            page.SetFocusToSelectYourBackgroundImage();
            page.BtnUploadPhoto.Click(5);
            page.BtnSelectPhotoFromComputer.Click(9);
            page.UploadPhotoFromComputer(imagePath);
        }

        public static bool IsUploadErrorOccured()
        {
            ThemesPage page = new ThemesPage();
            return page.LblUploadError.IsElementPresentOnPage(5);
        }

        public static void CloseThemesWindow()
        {
            ThemesPage page = new ThemesPage();
            page.BbtnClose.Click(5);
            page.ReturnFocusToThemesWindow();
            page.BtnSaveAndClose.Click(5);
        }
    }
}
