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
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            UnitGroupCreation();
            
            GroupData group = new GroupData("aaa"); //тут нужен 1 конструктор с параметром name, с др полями не нужен
            group.Header = "ddd"; //необязат поля
            group.Footer = "ccc";
            FillGroupForm(group);
            //если FillGroupForm(new GroupData("aaa")) - name передается тут, остальное задано в классе (напр, header = "")

            SubmitCreation();
            ReturnToGroupsPage();
        }   
    }
}
