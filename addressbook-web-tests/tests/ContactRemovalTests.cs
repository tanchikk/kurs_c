using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
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

            if (app.Contacts.ContactCreated() == false)
            {
                 app.Contacts.CreateContact(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemovalContact(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0); //указываем, что удален 1й в списке элемент
            Assert.AreEqual(oldContacts.Count, newContacts.Count); //прямое сравнение список

            Assert.IsTrue(app.Contacts.ContactCreated()); //false
        }
    }
}
