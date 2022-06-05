using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            app.Groups.GroupExistence();
            app.Contacts.ContactExistance();

            GroupData group = GroupData.GetAll()[0];
            app.Contacts.NoContactsExistInGroup(group);
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = group.GetContacts().First();

            //действия
            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
