using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Groups.GroupExistence();
            app.Contacts.ContactExistance();

            GroupData group = GroupData.GetAll()[0];
            app.Contacts.InContactsExistGroup(group);
            List<ContactData> oldList = group.GetContacts();
            ContactData contact =  ContactData.GetContactAll().Except(oldList).First(); //Except выкинули контакты, которые не входят в заданную группу

            //действия
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
