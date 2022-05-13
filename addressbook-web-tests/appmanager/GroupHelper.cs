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

        /*public bool GroupCreated(GroupData group)
        {
            return GroupCreated()
                   && driver.FindElement(By.XPath("//div[@id='content']/form/span")).Text == "(" + group.Name + ")"; 
            //пр*оверка на определенную переменную
        }*/

        public bool GroupCreated()
        {
            return IsElementPresent(By.Name("selected[]")); //проверка на наличие чек-бокса
        }


        public void Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click(); //index+1 для XPath чтобы нумерация шла с 0
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }
        //для группы конец

        public GroupHelper SubmitGroupCreation() 
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null; //чтобы пошло перезаполнение кэша при добавлении (нажатии на кнопку)
            return this;
        }

        //для модификации (метод Modify тут)
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper UnitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        //для кэша
        private List<GroupData> groupCache = null;

        // для списка
        public List<GroupData> GetGroupList() //переписали в кэш
        {
            if (groupCache == null) //если кэш пусотй - данные заполняются, иначе перезаполнения нет
            {
                groupCache = new List<GroupData>();
                //List<GroupData> groups = new List<GroupData>();
                //получение данных в список
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group")); //тэг span, класс group
                                                                                                       // ICollection - общий тип, List - конкретный тип
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text));
                }
            }

            return new List<GroupData>(groupCache); //кэш в список, тк просто кэш лучше не возвращать

            /*List<GroupData> groups = new List<GroupData>();
            //получение данных в список
            manager.Navigator.GoToGroupsPage(); 
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group")); //тэг span, класс group
            // ICollection - общий тип, List - конкретный тип
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;*/
        }
        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
