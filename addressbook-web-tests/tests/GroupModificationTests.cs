using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage();

            //действие
            GroupData newData = new GroupData("zzz");
            newData.Header = "ttt";
            newData.Footer = "kkk";

            if (app.Groups.GroupCreated() == false)
            {
                app.Groups.CteateGroup(newData);
            }

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData oldData = oldGroups[0]; //запоминаем группу, которую будем менять

            //app.Groups.Modify(0, newData); //сама модификация
            app.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //не изменено кол-во

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();

            //сортировка
            oldGroups[0].Name = newData.Name; //у элемента меняем имя, который модифицировали
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups) //проверка, что именно изменена та группа, которую выбрали вверху oldData
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(group.Name, newData.Name);
                }
            }

            Assert.IsTrue(app.Groups.GroupCreated()); 
        }
    }
}
