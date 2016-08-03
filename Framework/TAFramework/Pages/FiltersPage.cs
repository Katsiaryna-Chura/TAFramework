using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Elements;
using OpenQA.Selenium;

namespace TAFramework.Pages
{
    public class FiltersPage : BasePage
    {
        public Button BtnCreateNewFilter { get; private set; } = new Button(By.XPath
            ("//span[contains(.,'Create a new filter')]"));
        public TextInput TxtFrom { get; private set; } = new TextInput(By.XPath
            ("//span[label[contains(.,'From')]]/following-sibling::span/input"));
        public Checkbox CbHasAttachment { get; private set; } = new Checkbox(By.XPath
            ("//label[contains(.,'Has attachment')]/preceding-sibling::input"));
        public Link LinkCreateFilterWithThisSearch { get; private set; } = new Link(By.XPath
            ("//div[contains(text(),'Create filter with this search')]"));
        public Checkbox CbDeleteIt { get; private set; } = new Checkbox(By.XPath
            ("//label[contains(.,'Delete it')]/preceding-sibling::input"));
        public Checkbox CbMarkAsImportant { get; private set; } = new Checkbox(By.XPath
            ("//label[contains(.,'Always mark it as important')]/preceding-sibling::input"));
        public Button BtnConfirmCreation { get; private set; } = new Button(By.XPath
            ("//div[contains(text(),'Create filter')]"));
        public Button BtnSelectAll { get; private set; } = new Button(By.XPath
            ("//button[text()='Delete']/../../preceding-sibling::tr/td/span/span[text()='All']"));
        public Button BtnDelete { get; private set; } = new Button(By.XPath
            ("//button[text()='Delete']"));
        public Button BtnOk { get; private set; } = new Button(By.XPath
            ("//div[@role='alertdialog']//button[@name='ok']"));

        public FiltersPage() : base()
        {
            this.URL = "https://mail.google.com/mail/#settings/filters";
        }
    }
}
