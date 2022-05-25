using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase //наследник теста
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();

            GroupData groupdata = new GroupData("aaa"); //groupdata - локальная переменная, можно по равзному назвать
            groupdata.Header = "ddd";
            groupdata.Footer = "ccc";

                if (app.Groups.GroupCreated() == false)
                {
                    app.Groups.CteateGroup(groupdata);
                }
            Assert.IsTrue(app.Groups.GroupCreated());

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Removal(toBeRemoved); //само удаление

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount()); //минус 1, тк удаление

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();

            //GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0); //указываем, что удален 1й в списке элемент
            Assert.AreEqual(oldGroups.Count, newGroups.Count); //прямое сравнение список
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }


        }

    }
}
