using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.OpenHomePage();

            ContactData newContact = new ContactData("Tanya", "Kaz");
            newContact.Middlename = "Tan";
            newContact.Nickname = "Tank";
            newContact.Photo = "D:\\Users\\Tanchik\\Downloads\\shopping-cart.png";
            newContact.Title = "T";
            newContact.Company = "OOO";
            newContact.Address = "Москва";
            newContact.Home = "50";
            newContact.Mobile = "+79000000000";
            newContact.Work = "job";
            newContact.Fax = "525252";
            newContact.Email = "dfg@sdf.gh";
            newContact.Email2 = "dfg@sdf2.gh";
            newContact.Email3 = "dfg@sdf3.gh";
            newContact.Homepage = "dfg@sdf3.gh";
            newContact.Bday = "2";
            newContact.Bmonth = "March";
            newContact.Byear = "1990";
            newContact.Aday = "2";
            newContact.Amonth = "March";
            newContact.Ayear = "1991";
            newContact.Address2 = "Волгоград";
            newContact.Phone2 = "+70000000009";
            newContact.Notes = "pam";

            if (app.Contacts.ContactCreated() == false)
            {
                app.Contacts.CreateContact(newContact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldDataCon = oldContacts[0];

            app.Contacts.Modify(newContact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts) //проверка, что именно изменена та группа, которую выбрали вверху oldData
            {
                if (contact.Id == oldDataCon.Id)
                {
                    Assert.AreEqual(contact.Firstname, newContact.Firstname);
                    Assert.AreEqual(contact.Lastname, newContact.Lastname);
                }
            }

            //Assert.IsFalse(app.Contacts.ContactCreated(newContact));
            Thread.Sleep(1000);
        }

        [Test]
        public void DetailsContactModificationTest()
        {
            app.Navigator.OpenHomePage();

            ContactData newContact = new ContactData("Tanya", "Kaz");
            newContact.Middlename = "Tan";
            newContact.Nickname = "Tank";
            newContact.Photo = "D:\\Users\\Tanchik\\Downloads\\shopping-cart.png";
            newContact.Title = "T";
            newContact.Company = "OOO";
            newContact.Address = "Москва";
            newContact.Home = "50";
            newContact.Mobile = "+79000000000";
            newContact.Work = "job";
            newContact.Fax = "525252";
            newContact.Email = "dfg@sdf.gh";
            newContact.Email2 = "dfg@sdf2.gh";
            newContact.Email3 = "dfg@sdf3.gh";
            newContact.Homepage = "dfg@sdf3.gh";
            newContact.Bday = "2";
            newContact.Bmonth = "March";
            newContact.Byear = "1990";
            newContact.Aday = "2";
            newContact.Amonth = "March";
            newContact.Ayear = "1991";
            newContact.Address2 = "Волгоград";
            newContact.Phone2 = "+70000000009";
            newContact.Notes = "pam";

            if (app.Contacts.ContactCreated() == false)
            {
                app.Contacts.CreateContact(newContact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldDataCon = oldContacts[0];

            app.Contacts.Modify(newContact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts) //проверка, что именно изменена та группа, которую выбрали вверху oldData
            {
                if (contact.Id == oldDataCon.Id)
                {
                    Assert.AreEqual(contact.Firstname, newContact.Firstname);
                    Assert.AreEqual(contact.Lastname, newContact.Lastname);
                }
            }

            Thread.Sleep(1000);
        }
    }
}
