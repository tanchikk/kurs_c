using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Parquet.Thrift;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase //класс, чтобы залогиниться
    {
        [Test]
        public void LoginWithValidCreadentials() 
        {
            //подготовка            
            app.Auth.Logout();
            Thread.Sleep(1000);

            //действие
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //проверка
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
      

        [Test]
        public void LoginWithInvalidCreadentials()
        {
            //подготовка
            app.Auth.Logout();
            Thread.Sleep(1000);

            //действие
            AccountData account = new AccountData("admin", "13554");
            app.Auth.Login(account);

            //проверка
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
