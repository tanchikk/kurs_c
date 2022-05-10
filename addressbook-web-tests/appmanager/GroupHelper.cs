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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }   

        public GroupHelper CteateGroup(GroupData group) //перенос посторных методов в [Test]-ах
        {
            manager.Navigator.GoToGroupsPage(); //GroupHelper берет методы Navigator через менеджера
            UnitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }     

        
        public GroupHelper Removal(int v) //поставила void
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public bool GroupCreated(GroupData group)
        {
            return GroupCreated()
            && driver.FindElement(By.XPath("//div[@id='content']/form/span")).Text == "(" + group.Name + ")"; 
            //проверка на определенную переменную
        }

        public bool GroupCreated()
        {
            return IsElementPresent(By.Name("selected[]")); //проверка на наличие чек-бокса
        }


        public void Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();

            if (GroupCreated() == false)
            {
                if (GroupCreated(newData) == false)
                {
                    CteateGroup(newData);
                }
            }

            SelectGroup(v);
            UnitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();       

        }

        //для групп начало
        public GroupHelper UnitGroupCreation() //вместо void - GroupHelper
        {
            driver.FindElement(By.Name("new")).Click();
            return this; // + тк GroupHelper (в хелпере вызываем метод и возврается ссылка на него самого)
        }

        public GroupHelper FillGroupForm(GroupData group)
        {          
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }        

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        //для группы конец

        public GroupHelper SubmitGroupCreation() 
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        //для модификации (метод Modify тут)
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper UnitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
