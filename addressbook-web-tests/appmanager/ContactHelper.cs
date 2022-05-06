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

        public void RemovalContact(int v, ContactData contact)
        {
            if (ContactCreated() == false)
            {
                if (ContactCreated(contact) == false)
                {
                    CreateContact(contact);
                }
            }

            SelectContact(v);
            RemoveContact();
            manager.Navigator.OpenHomePage();
        }

        

        public void Modify(ContactData newContact)
        {
            if (ContactCreated() == false)
            {
                if (ContactCreated(newContact) == false)
                {
                    CreateContact(newContact);
                }
            }

            UnitContactModification();
            FillContactForm(newContact);
            SubmitContactModification();
            manager.Navigator.OpenHomePage();

        }

        public void DetailsModify(ContactData newContact)
        {
            if (ContactCreated() == false)
            {
                if (ContactCreated(newContact) == false)
                {
                    CreateContact(newContact);
                }
            }

            UnitDetailsContactModification();
            ModifiyDetailsContact();
            FillContactForm(newContact);
            SubmitContactModification();
            manager.Navigator.OpenHomePage();

        }

        public bool ContactCreated(ContactData contact)
        {
            return ContactCreated()
            //&& driver.FindElement(By.XPath("//div[@id='content']/form/span")).Text == "(" + contact.Firstname + ")";
            && driver.FindElement(By.Name("entry")).FindElement(By.TagName("td")).Text
                == "(" + contact.Firstname + ")";
        }

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
            Type(By.Name("photo"), contact.Photo);
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
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            Type(By.Name("byear"), contact.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("9");
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("September");
            Type(By.Name("ayear"), contact.Ayear);
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
            return this;
        }
        //для контактов конец

        public ContactHelper RemoveContact()
        {
            //acceptNextAlert = true;
            driver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            //Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            driver.SwitchTo().Alert().Accept();            
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper UnitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
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
    }
}
