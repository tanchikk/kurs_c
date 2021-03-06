using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        //protected bool acceptNextAlert = true;

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            UnitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();
            return this;
        }     

        public ContactHelper RemovalContact(int v)
        {       
            SelectContact(v);
            RemoveContact();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper RemovalContact(ContactData contact)
        {
            SelectContact(contact.Id);
            RemoveContact();
            manager.Navigator.OpenHomePage();
            return this;
        }


        public void Modify(ContactData newContact, int v)
        {
            UnitContactModification(v);
            FillContactForm(newContact);
            SubmitContactModification();
            manager.Navigator.OpenHomePage();
        }

        public void Modify(ContactData newContact, ContactData contact)
        {
            UnitContactModification(contact.Id);
            FillContactForm(newContact);
            SubmitContactModification();
            manager.Navigator.OpenHomePage();
        }

        public void DetailsModify(ContactData newContact)
        {
            UnitDetailsContactModification();
            ModifiyDetailsContact();
            FillContactForm(newContact);
            SubmitContactModification();
            manager.Navigator.OpenHomePage();
        }        

        /*public bool ContactCreated(ContactData contact)
        {
            return ContactCreated()
            //&& driver.FindElement(By.XPath("//div[@id='content']/form/span")).Text == "(" + contact.Firstname + ")";
            && driver.FindElement(By.Name("entry")).FindElement(By.TagName("td")).Text
                == "(" + contact.Firstname + ")";
        }*/

        public bool ContactCreated()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        //для контактов начало
        public ContactHelper UnitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            //Type(By.Name("photo"), contact.Photo);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);          
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            //Type(By.Name("byear"), contact.Byear);
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            //Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }        

        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }
        //для контактов конец

        public ContactHelper RemoveContact()
        {
            //acceptNextAlert = true;
            driver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            //Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            contactCache = null;
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(String contactid)
        {
            //driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            //driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            driver.FindElement(By.Id(contactid)).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper UnitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7] //элемент редактировния с индексом 7
                .FindElement(By.TagName("a")).Click();
            //driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper UnitContactModification(String id)
        {
            driver.FindElement(By.XPath(String.Format("//a[@href='edit.php?id={0}']", id))).Click();
            return this;
        }


        public ContactHelper UnitDetailsContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            return this;
        }
        public ContactHelper ModifiyDetailsContact()
        {
            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        private List<ContactData> contactCache = null;
        // для списка
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                //List<ContactData> contacts = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in elements)
                {
                    if (!element.Displayed) //что не отображается - пропускается
                    {
                        continue; //пропускается
                    }

                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                    //{
                    //    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    //});
                }
            }
            return new List<ContactData>(contactCache);

            /*foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                contactCache.Add(new ContactData(cells[2].Text, cells[1].Text));
                //{
                //    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                //});
            }*/



            /*List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactData(cells[2].Text, cells[1].Text));
            }
            return contacts;*/

            /*ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[2]"));
            int i = 1;
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(driver.FindElement(By.XPath("//tbody/tr[" + (i + 1) + "]/td[3]")).Text,
                    driver.FindElement(By.XPath("//tbody/tr[" + (i + 1) + "]/td[2]")).Text));
                i++;
            }
            return contacts;*/
        }

        public int GetContactsCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allPhone = cells[5].Text;
            string allEmail = cells[4].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhone,
                AllEmail = allEmail
            };
        }        

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            UnitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Phone2 = phone2,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };            
        }

        public ContactData GetContactInformationFromEditFormDetails(int index) //для 12
        {
            manager.Navigator.OpenHomePage();
            UnitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");



            /*string bday = driver.FindElement(By.XPath("//select[@name='bday']/option[@selected='selected']")).GetAttribute("value");
            string bmonth = driver.FindElement(By.XPath("//select[@name='bmonth']/option[@selected='selected']")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.XPath("//select[@name='aday']/option[@selected='selected']")).GetAttribute("value");
            string amonth = driver.FindElement(By.XPath("//select[@name='amonth']/option[@selected='selected']")).GetAttribute("value");
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.XPath("//select[@name='amonth']/option[@selected='selected']")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");*/

            //string address2 = driver.FindElement(By.Name("address2")).Text;
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            //string notes = driver.FindElement(By.Name("notes")).Text;
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");
            
            return new ContactData(firstname, lastname)
            {
                Middlename = middlename,
                Nickname = nickname,

                Company = company,
                Title = title,
                Address = address,

                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,

                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,                
                
                /*Bday = bday,
                Bmonth = bmonth,
                Byear = byear,

                Aday = aday,
                Amonth = amonth,
                Ayear = ayear,*/

                Address2 = address2,
                Phone2 = phone2,
                Notes = notes,

            };
        }

        public ContactData GetContactInformationFromTableDetails() //для 12
        {
            manager.Navigator.OpenHomePage();
            UnitDetailsContactModification();

            string firstname = null;
            string lastname = null;

            string allContactDetails = driver.FindElement(By.CssSelector("div#content")).Text;

            return new ContactData(firstname, lastname)
            {
                AllContactDetails = allContactDetails
            };
        }

        public int GetNumberOfSearchResults()
        {
            //manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text; //строка, к которой применяем рег.выражение
            Match m = new Regex(@"\d+").Match(text); //регулярное выражение применяем к тексту
            return Int32.Parse(m.Value); //взяли нужную часть строки
        }

        public void SearchInput()
        {
            driver.FindElement(By.Name("searchstring")).SendKeys("a");
        }

        public void AddContactToGroup(ContactData contact, GroupData group) //добавление группы в контакт
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0); //подождать появления сообщения о том, что группа добавлена (кол-во эл-тов > 0), а потом считывается в тесте новый список
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group) //добавление группы в контакт
        {
            manager.Navigator.OpenHomePage();
            SelectGroupToRemove(group.Name);
            SelectContact(contact.Id);
            CommitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0); //подождать появления сообщения о том, что группа добавлена (кол-во эл-тов > 0), а потом считывается в тесте новый список
        }

        private void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupToRemove(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public ContactHelper ContactExistance() //проверка что контакт создан, иначе создать его
        {
            manager.Navigator.OpenHomePage();
            if (!IsElementPresent(By.Name("entry")))
            {
                ContactData contact = new ContactData("First", "Last");
                CreateContact(contact);
            }
            return this;
        }

        public void InContactsExistGroup(GroupData group) //проверка есть ли контакт в группе - удалить группу
        {
            if (ContactData.GetContactAll().Except(group.GetContacts()).Count() == 0)
            {
                ContactData contact = group.GetContacts().First();

                RemoveContactFromGroup(contact, group);
            }
        }

        public void NoContactsExistInGroup(GroupData group) //проверка если нет контакта в группе - добавить группу
        {
            if (group.GetContacts().Count() == 0)
            {
                ContactData contact = ContactData.GetContactAll().First();

                AddContactToGroup(contact, group);
            }
        }

    }
}
