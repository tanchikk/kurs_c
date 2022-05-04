using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            newContact.Ayear = "1991";
            newContact.Address2 = "Волгоград";
            newContact.Phone2 = "+70000000009";
            newContact.Notes = "pam";

            app.Contacts.Modify(newContact);

        }

        [Test]
        public void DetailsContactModificationTest()
        {
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
            newContact.Ayear = "1991";
            newContact.Address2 = "Волгоград";
            newContact.Phone2 = "+70000000009";
            newContact.Notes = "pam";

            app.Contacts.DetailsModify(newContact);
        }
    }
}
