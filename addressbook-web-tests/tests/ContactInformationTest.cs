using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation() //сравнение инфы контакта с гл.страницы и редактируемой
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0); //получение инфы о контакте с гл.страницы
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0); //получение инфы о контакте с формы редактир

            //проверки
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }

        [Test]
        public void TestContactInformationDetails() //сравнение инфы контакта с гл.страницы и редактируемой
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTableDetails(); //получение инфы о контакте с гл.страницы
            ContactData fromForm = app.Contacts.GetContactInformationFromEditFormDetails(); //получение инфы о контакте с формы редактир

            //проверки
            Console.Out.Write(app.Contacts.GetContactInformationFromTableDetails());
            Console.Out.Write(app.Contacts.GetContactInformationFromEditFormDetails());
            Assert.AreEqual(fromTable.AllContactDetails, fromForm.AllContactDetails);
        }
    }
}
