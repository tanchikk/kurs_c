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

        public bool IsLoggedIn(AccountData account) // условие залогинен под ...
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Username; //извлечение строки под строку, извлечение из ЮИ извлекает имя пользака залогиненного
                
        }

        public string GetLoggetUserName() //метод проверяет логин пользака, под которым зашли
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text; //нашли тут элемент
            return text.Substring(1, text.Length - 2); //вырезали из (admin) только admin без скобок, индексация с 0, но берем с 1 и длина -2
                                                       // == System.String.Format("(${0})", account.Username); вместо "(" + account.Username + ")";
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
