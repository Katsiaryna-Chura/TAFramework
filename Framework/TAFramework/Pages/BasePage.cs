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
        public Button BbtnCompose { get; private set; } = new Button(By.XPath("//div[@gh='cm']"));
        public Button BtnSend { get; private set; } = new Button(By.XPath("//div[contains(@aria-label,'Send')]"));

        public TextInput TxtTo { get; private set; } = new TextInput(By.XPath("//textarea[@name='to']"));
        public TextInput TxtMessage { get; private set; } = new TextInput(By.XPath("//div[@role='textbox']"));
        public TextInput TxtSubject { get; private set; } = new TextInput(By.XPath("//input[@name='subjectbox']"));

        public Button BtnAttachFile { get; private set; } = new Button(By.XPath("//div[@aria-label='Attach files']"));

        //public BaseElement Message = new BaseElement();
        public BaseElement Alert { get; private set; } = new BaseElement(By.XPath("//div[@role='alertdialog']/descendant::span[text()='Large files must be shared with Google Drive']"));//descendant::span[text()='Large files must be shared with Google Drive']
        public Button BtnCloseAlert { get; private set; } = new Button(By.XPath("//div[@role='alertdialog']/descendant::span[@aria-label='Close']"));

        public Button BtnInsertEmoticon { get; private set; } = new Button(By.XPath("//div[contains(@aria-label,'Insert emoticon')]"));
        public Button BtnShowFaceEmoticons { get; private set; } = new Button(By.XPath("//button[@title='Show face emoticons']"));
        public Button BtnEmoticon { get; private set; } = new Button();

        public Label LblSignature { get; private set; } = new Label(By.XPath("//div[@class='gmail_signature']/div"));
        public Button BtnCloseMessage { get; private set; } = new Button(By.XPath("//img[@aria-label='Save & Close']"));

        public Button BtnAccount { get; private set; } = new Button(By.XPath("//span[@class='gb_3a gbii']"));
        public Button BtnSignOut { get; private set; } = new Button(By.XPath("//a[contains(.,'Sign out')]"));

        public Button BtnAllSettings { get; private set; } = new Button(By.XPath("//div[@class='aos T-I-J3 J-J5-Ji']"));
        public Link LinkToSettings { get; private set; } = new Link(By.XPath("//div[@id='ms']"));

        public TextInput TxtSearchText { get; private set; } = new TextInput(By.XPath("//h2[text()='Search']/../descendant::input"));
        public Button BtnSearch { get; private set; } = new Button(By.XPath("//button[@aria-label='Search Gmail']"));

        public Link LinkToThemes { get; private set; } = new Link(By.XPath("//div[text()='Themes']"));

        public Link linkStarred { get; private set; } = new Link(By.XPath("//a[@title='Starred']"));

        public BasePage()
        {
            this.URL = "https://mail.google.com";
        }

        public void WaitForPageToLoad()
        {
            Thread.Sleep(4000);
            //WebDriver.GetDriver().WaitForElementToBeVisible(By.XPath("//div[@class='jr']"));
            //button[@title='Find people to chat with']
        }

        public bool AttachSpecifiedFile(string filepath)
        {
            System.Windows.Forms.SendKeys.SendWait(filepath);

            Thread.Sleep(1000);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            Thread.Sleep(5000);
            Link attachedFile = new Link();
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
