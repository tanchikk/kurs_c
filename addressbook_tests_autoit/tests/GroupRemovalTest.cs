using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTest : TestBase
{
        [Test]
        public void TestGroupRemoval()
        {
            GroupData group = new GroupData()
            {
                Name = "test"
            };

            if (app.Groups.GetGroupList().Count == 1) //если остается 1 группа, то ее невозможно удалить => нужно создать
            {
                app.Groups.Add(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Removal();

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
