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
            app.Groups.Modify(1, newData);

            //проверка
            Assert.IsFalse(app.Groups.GroupCreated(newData)); //false
        }
    }
}
