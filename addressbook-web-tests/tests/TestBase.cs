using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase //класс для наследования (поля и классы public / protected для доступа к ним)
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret")); // + loginHelper.
        }

        [TearDown]
        public void TeardownTest() 
        {
            app.Stop(); //метод вынесен в ApplicationManager
        }        
    }
}
