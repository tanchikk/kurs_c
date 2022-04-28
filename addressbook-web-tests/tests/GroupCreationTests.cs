using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase //наследник теста
    {
        [Test]
        public void GroupCreationTest()
        {            
            GroupData group = new GroupData("aaa"); //тут нужен 1 конструктор с параметром name, с др полями не нужен
            group.Header = "ddd"; //необязат поля
            group.Footer = "ccc";            
            app.Groups.CteateGroup(group); // переименовать в Cteate
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.CteateGroup(group); // CteateGroup с методами вынесен в GroupHelper
        }
    }
}
