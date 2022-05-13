using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic; //для List<GroupData>
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase //наследник теста
    {
        [Test]
        public void GroupCreationTest()
        {            
            GroupData group = new GroupData("aaa"); //тут нужен 1 конструктор с параметром name, с др полями не нужен
            group.Header = "ddd"; //необязат поля
            group.Footer = "ccc";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //получение списка групп До создания новой

            app.Groups.CteateGroup(group); //создание группы

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //app.Groups.GetGroupCount() кол-во групп и сравнение 

            List<GroupData> newGroups = app.Groups.GetGroupList(); //получение списка групп После создания новой            
            
            //сортировка
            oldGroups.Add(group); //указываем добавленный элемент
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //проверяет равность объектов
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //получение списка групп До создания новой

            app.Groups.CteateGroup(group); // CteateGroup с методами вынесен в GroupHelper

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList(); //получение списка групп После создания новой            
            
            //сортировка
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BagNameGroupCreationTest() //группа с недопустимым символом ' в имени не создается, упадет на проверке Expected:3 != But was:2
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //получение списка групп До создания новой

            app.Groups.CteateGroup(group); // CteateGroup с методами вынесен в GroupHelper

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList(); //получение списка групп После создания новой
            
            //сортировка
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
