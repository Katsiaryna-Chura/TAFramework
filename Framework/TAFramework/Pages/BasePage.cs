using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Pages;
using Framework.Core.Elements;
using OpenQA.Selenium;
using System.Threading;

namespace TAFramework.Pages
{
    public class BasePage:AbstractPage
    {
        public Button BbtnCompose { get; private set; } = new Button
            (By.XPath("//div[@gh='cm']"),"button 'Compose'");
        public Button BtnSend { get; private set; } = new Button
            (By.XPath("//div[contains(@aria-label,'Send')]"),"button 'Send'");

        public TextInput TxtTo { get; private set; } = new TextInput
            (By.XPath("//textarea[@name='to']"),"text input 'To'");
        public TextInput TxtMessage { get; private set; } = new TextInput
            (By.XPath("//div[@role='textbox']"), "text input 'Message'");
        public TextInput TxtSubject { get; private set; } = new TextInput
            (By.XPath("//input[@name='subjectbox']"), "text input 'Subject'");

        public Button BtnAttachFile { get; private set; } = new Button
            (By.XPath("//div[@aria-label='Attach files']"),"button Attach file");

        public BaseElement Alert { get; private set; } = new BaseElement(By.XPath
            ("//div[@role='alertdialog']/descendant::span[text()='Large files must be shared with Google Drive']"),"alert dialog 'Large files'");
        public Button BtnCloseAlert { get; private set; } = new Button
            (By.XPath("//div[@role='alertdialog']/descendant::span[@aria-label='Close']"),"button 'Close alert'");

        public Button BtnInsertEmoticon { get; private set; } = new Button
            (By.XPath("//div[contains(@aria-label,'Insert emoticon')]"),"button 'Insert emoticon'");
        public Button BtnShowFaceEmoticons { get; private set; } = new Button
            (By.XPath("//button[@title='Show face emoticons']"),"button 'Show face emoticon'");
        public Button BtnEmoticon { get; private set; } = new Button("concrete emoticon button");

        public Label LblSignature { get; private set; } = new Label
            (By.XPath("//div[@class='gmail_signature']/div"),"label 'Signature'");
        public Button BtnCloseMessage { get; private set; } = new Button
            (By.XPath("//img[@aria-label='Save & Close']"),"button 'Close message'");

        public Button BtnAccount { get; private set; } = new Button
            (By.XPath("//span[@class='gb_3a gbii']"),"button 'Account'");
        public Button BtnSignOut { get; private set; } = new Button
            (By.XPath("//a[contains(.,'Sign out')]"),"button 'Sign out'");

        public Button BtnAllSettings { get; private set; } = new Button
            (By.XPath("//div[@class='aos T-I-J3 J-J5-Ji']"),"button 'All settings'");
        public Link LinkToSettings { get; private set; } = new Link
            (By.XPath("//div[@id='ms']"),"link 'Settings'");

        public TextInput TxtSearchText { get; private set; } = new TextInput
            (By.XPath("//h2[text()='Search']/../descendant::input"),"text input 'Search'");
        public Button BtnSearch { get; private set; } = new Button
            (By.XPath("//button[@aria-label='Search Gmail']"), "button 'Search Gmail'");

        public Link LinkToThemes { get; private set; } = new Link
            (By.XPath("//div[text()='Themes']"),"link 'Themes'");

        public Link linkStarred { get; private set; } = new Link
            (By.XPath("//a[@title='Starred']"),"link 'Starred'");

        public BasePage()
        {
            this.URL = "https://mail.google.com";
        }

        public void WaitForPageToLoad()
        {
            Thread.Sleep(3000);
            //WebDriver.GetDriver().WaitForElementToBeVisible(By.XPath("//div[@class='jr']"));
            //button[@title='Find people to chat with']
        }

        public void WaitForReplyMessageToBeDelivered()
        {
            Thread.Sleep(9000);
        }

        public bool AttachSpecifiedFile(string filepath)
        {
            System.Windows.Forms.SendKeys.SendWait(filepath);
            Thread.Sleep(3000);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            Thread.Sleep(3000);
            Link attachedFile = new Link("link 'Attached file'");
            attachedFile.By = By.XPath($"//div[contains(text(),'{filepath.Substring(filepath.LastIndexOf('\\') + 1)}')]/ancestor::a");
            if (attachedFile.IsElementPresentOnPage(7))
            {
                attachedFile.WaitForElementToBeClickable(7);
                return true;
            }
            else
                return false;
        }

        public void AddEmoticonsToMessage(params int[] emoticonNum)
        {
            foreach (var emoticon in emoticonNum)
            {
                BtnEmoticon.By = By.XPath($"//button[@class='a8m']/../../div[1]/button[{emoticon}]");
                BtnEmoticon.Click(5);
            }
        }

    }
}
