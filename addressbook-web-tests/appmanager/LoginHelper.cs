using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
            if (IsLoggedIn()) //условие на залогинен ли или нет
            {
                if (IsLoggedIn(account)) 
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);            
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }     

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                == "(" + account.Username + ")"; //условие залогинен под ...

        }

        public void Logout()
        {

            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }            
        }
    }
}
