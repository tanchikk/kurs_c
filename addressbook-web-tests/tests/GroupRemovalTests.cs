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
            app.Navigator.GoToGroupsPage();

            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "ccc";

            if (app.Groups.GroupCreated() == false)
            {
                if (app.Groups.GroupCreated(group) == false)
                {
                    app.Groups.CteateGroup(group);
                }
            }

            //действие            
            app.Groups.Removal(1);

            //проверка
            Assert.IsFalse(app.Groups.GroupCreated(group)); //false
        }

    }
}
