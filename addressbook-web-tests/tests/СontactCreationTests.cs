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
        
        public static IEnumerable<ContactData> RandomGroupDataProviderContact()
        {
            List<ContactData> groups = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new ContactData(GenerateRandomStringContact(30), GenerateRandomStringContact(30))
                {
                    Middlename = GenerateRandomStringContact(100),
                    Nickname = GenerateRandomStringContact(100),
                    //Photo = GenerateRandomStringContact(100),
                    Title = GenerateRandomStringContact(100),
                    Company = GenerateRandomStringContact(100),
                    Address = GenerateRandomStringContact(100),
                    Home = GenerateRandomStringContact(100),
                    Mobile = GenerateRandomStringContact(100),
                    Work = GenerateRandomStringContact(100),
                    Fax = GenerateRandomStringContact(100),
                    Email = GenerateRandomStringContact(100),
                    Email2 = GenerateRandomStringContact(100),
                    Email3 = GenerateRandomStringContact(100),
                    Homepage = GenerateRandomStringContact(100),
                    Bday = GenerateRandomStringContact(100),
                    Bmonth = GenerateRandomStringContact(100),
                    Byear = GenerateRandomStringContact(100),
                    Aday = GenerateRandomStringContact(100),
                    Amonth = GenerateRandomStringContact(100),
                    Ayear = GenerateRandomStringContact(100),
                    Address2 = GenerateRandomStringContact(100),
                    Phone2 = GenerateRandomStringContact(100),
                    Notes = GenerateRandomStringContact(100)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProviderContact")]
        public void СontactCreationTest(ContactData contact)
        {       

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

       /* [Test]
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
            contact.Aday = "2";
            contact.Amonth = "March";
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
