using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            app.Navigator.OpenHomePage();
            app.Contacts.SearchInput();
            app.Contacts.GetNumberOfSearchResults();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            //Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
            //Console.Out.Write(oldContacts.Count);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetNumberOfSearchResults());
        }
    }
}