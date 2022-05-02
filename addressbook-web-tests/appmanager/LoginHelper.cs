using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase //класс помощник public
    {
        public LoginHelper(ApplicationManager manager) // конструктор public
            : base(manager) //ссыль на конструктор HelperBase
        {
        }

        public void Login(AccountData account) //метод public
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);            
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}
