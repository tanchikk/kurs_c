using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class СontactCreationTests : AuthTestBase // наследие
    {     
        [Test]
        public void СontactCreationTest()
        {         
            ContactData contact = new ContactData("Tanya", "Kaz");
            contact.Middlename = "Tan";
            contact.Nickname = "Tank";
            contact.Photo = "D:\\Users\\Tanchik\\Downloads\\shopping-cart.png";
            contact.Title = "T";
            contact.Company = "OOO";
            contact.Address = "Москва";
            contact.Home = "50";
            contact.Mobile = "+79000000000";
            contact.Work = "job";
            contact.Fax = "525252";
            contact.Email = "dfg@sdf.gh";
            contact.Email2 = "dfg@sdf2.gh";
            contact.Email3 = "dfg@sdf3.gh";
            contact.Homepage = "dfg@sdf3.gh";
            contact.Bday = "2";
            contact.Bmonth = "March";
            contact.Byear = "1990";
            contact.Ayear = "1991";
            contact.Address2 = "Волгоград";
            contact.Phone2 = "+70000000009";
            contact.Notes = "pam";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            //Assert.AreEqual(oldContacts.Count+1, newContacts.Count);
            
            //сортировка
            oldContacts.Add(contact); //указываем добавленный элемент
            //Assert.AreEqual(oldContacts.Count, newContacts.Count);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        /*[Test]
        public void TestContactComparator()
        {
            ContactData contact1 = new ContactData("Adam", "Smith");
            ContactData contact2 = new ContactData("Bob", "Smith");
            Assert.AreEqual(contact2.CompareTo(contact1), 1);
        }*/
    }
}
