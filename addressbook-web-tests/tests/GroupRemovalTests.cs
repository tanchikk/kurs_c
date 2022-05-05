using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase //наследник теста
    {
        [Test]
        // public void GroupRemovalTest()
        // {
        //     app.Groups.Removal(1);
        // }
        public void GroupRemovalTest()
        {
            //действие
            GroupData group = new GroupData("aaa"); 
            group.Header = "ddd"; 
            group.Footer = "ccc";
            app.Groups.Removal(1, group);

            //проверка
            Assert.IsTrue(app.Groups.GroupCreated(group));
        }

    }
}
