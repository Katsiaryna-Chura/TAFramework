﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Elements;
using OpenQA.Selenium;
using System.Threading;
using Framework.Core.Utilities;

namespace TAFramework.Pages
{
    public class ThemesPage : BasePage
    {
        public Link LinkSetTheme { get; private set; } = new Link
            (By.XPath("//a[contains(text(), 'Set Theme')]"),"link 'Set Theme'");
        public Button BtnMyPhotos { get; private set; } = new Button
            (By.XPath("//div[text()='My Photos']"),"button 'My photos'");
        public Button BtnUploadPhoto { get; private set; } = new Button
            (By.XPath("//div[text()='Upload a photo']"),"button 'Upload a photo'");
        public Button BtnSelectPhotoFromComputer { get; private set; } = new Button
            (By.XPath("//div[text()='Select a photo from your computer']"),"button 'Select photo from your computer'");
        public Label LblUploadError { get; private set; } = new Label
            (By.XPath("//span[contains(text(),'There was an upload error')]"),"label 'Upload error'");
        public Button BtnClose { get; private set; } = new Button
            (By.XPath("//div[@aria-label='Close']"),"button 'Close'");
        public Button BtnSaveAndClose { get; private set; } = new Button
            (By.XPath("//span[@aria-label='Close']"),"button 'Save and close'");

        public ThemesPage() : base()
        {
            this.URL = "https://mail.google.com/mail/#settings/oldthemes";
        }

        public void SetFocusToSelectYourBackgroundImage()
        {
            WebDriver.GetDriver().SwitchTo().Frame(WebDriver.GetDriver().FindElement(By.XPath("//iframe[@class='KA-JQ']")));
        }

        public void ReturnFocusToThemesWindow()
        {
            WebDriver.GetDriver().SwitchTo().DefaultContent();
        }

        public void UploadPhotoFromComputer(string imagePath)
        {
            System.Windows.Forms.SendKeys.SendWait(imagePath);
            Thread.Sleep(2000);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
        }
    }
}
