using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            //действие
            GroupData newData = new GroupData("zzz");
            newData.Header = "ttt";
            newData.Footer = "kkk";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData); //сама модификация

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //не изменено кол-во

            List<GroupData> newGroups = app.Groups.GetGroupList();

            //сортировка
            oldGroups[0].Name = newData.Name; //у элемента меняем имя, который модифицировали
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            Assert.IsFalse(app.Groups.GroupCreated(newData)); //false
        }
    }
}
