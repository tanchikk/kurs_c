using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown] //будет выполлняться после каждого теста в конце
        public void CompareGroupsUI_DB()
        {
            List<GroupData> fromUI = app.Groups.GetGroupList();
            List<GroupData> fromDB = GroupData.GetAll();
            fromUI.Sort();
            fromDB.Sort();
            Assert.AreEqual(fromUI, fromDB);
        }
    }
}
