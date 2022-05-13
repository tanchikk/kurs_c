using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase //наследник теста
    {
        [Test]
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
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Removal(0); //само удаление

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount()); //минус 1, тк удаление

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0); //указываем, что удален 1й в списке элемент
            Assert.AreEqual(oldGroups.Count, newGroups.Count); //прямое сравнение список

            Assert.IsFalse(app.Groups.GroupCreated(group)); //false
        }

    }
}
