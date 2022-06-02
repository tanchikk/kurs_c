using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class СontactCreationTests : ContactTestBase // наследие
    {
        
        public static IEnumerable<ContactData> RandomGroupDataProviderContact()
        {
            List<ContactData> groups = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new ContactData(GenerateRandomStringContact(20), GenerateRandomStringContact(20))
                {
                    Middlename = GenerateRandomStringContact(20),
                    Nickname = GenerateRandomStringContact(20),
                    //Title = GenerateRandomStringContact(20),
                    //Company = GenerateRandomStringContact(20),
                    Address = GenerateRandomStringContact(20),
                    Home = GenerateRandomStringContact(20),
                    Mobile = GenerateRandomStringContact(20),
                    Work = GenerateRandomStringContact(20),
                    //Fax = GenerateRandomStringContact(20),
                    Email = GenerateRandomStringContact(20),
                    Email2 = GenerateRandomStringContact(20),
                    Email3 = GenerateRandomStringContact(20),
                    Homepage = GenerateRandomStringContact(20)
                    //Address2 = GenerateRandomStringContact(50),
                    //Phone2 = GenerateRandomStringContact(20),
                    //Notes = GenerateRandomStringContact(50)
                });
            }
            return groups;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>) //явно приводим к типу (List<GroupData>)
                new XmlSerializer(typeof(List<ContactData>)).
                Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]  
        public void СontactCreationTest(ContactData contact)
        {       

            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetContactAll();

            app.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            //List<ContactData> newContacts = app.Contacts.GetContactList();
            List<ContactData> newContacts = ContactData.GetContactAll();

            //Assert.AreEqual(oldContacts.Count+1, newContacts.Count);

            //сортировка
            oldContacts.Add(contact); //указываем добавленный элемент
            //Assert.AreEqual(oldContacts.Count, newContacts.Count);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void TestDBConnectivityCon()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUi = app.Contacts.GetContactList(); //чтение из ЮИ
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start)); //end минус start

            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetContactAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            /*foreach (ContactData contact in ContactData.GetContactAll()) //проверка дат
            {
                System.Console.Out.WriteLine(contact.Deprecated);
            }*/
        }

        /*[Test]
        public void СontactCreationTest1()
        {         
            ContactData contact = new ContactData("Tanya", "Kaz");
            contact.Middlename = "Tan";
            contact.Nickname = "Tank";
            //contact.Photo = "D:\\Users\\Tanchik\\Downloads\\shopping-cart.png";
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
            //contact.Bday = "2";
            //contact.Bmonth = "March";
            //contact.Byear = "1990";
           // contact.Aday = "2";
            //contact.Amonth = "March";
            //contact.Ayear = "1991";
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
