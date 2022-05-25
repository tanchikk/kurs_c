using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic; //для List<GroupData>
using NUnit.Framework;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase //наследник теста
    {
        /*[Test]
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
        }*/

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv"); //читаем все строки
            foreach (string l in lines)
            {
                string[] parts = l.Split(','); //разбиваем строку с разделителем-запятая
                groups.Add(new GroupData(parts[0]) 
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            //List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>) //явно приводим к типу (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>)).
                Deserialize(new StreamReader(@"groups.xml")); 
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            //List<GroupData> oldGroups = app.Groups.GetGroupList(); //получение списка групп До создания новой
            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.CteateGroup(group); //создание группы

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //app.Groups.GetGroupCount() кол-во групп и сравнение 

            //List<GroupData> newGroups = app.Groups.GetGroupList(); //получение списка групп После создания новой            
            List<GroupData> newGroups = GroupData.GetAll();

            //сортировка
            oldGroups.Add(group); //указываем добавленный элемент
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //проверяет равность объектов
        }

       /* [Test]
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
        }*/

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

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupList(); //чтение из ЮИ
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start)); //end минус start

            start = DateTime.Now;
            List<GroupData> fromDb = GroupData.GetAll();
           /*using (AddressBookDB db = new AddressBookDB())
           {
               List<GroupData> fromDb = (from g in db.Groups select g).ToList(); //чтение из БД
               //db.Close(); вызывается автоматом
           }

           AddressBookDB db = new AddressBookDB();
           List<GroupData> fromDb = (from g in db.Groups select g).ToList(); //чтение из БД
           db.Close(); //закрыли бд*/

           end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}
