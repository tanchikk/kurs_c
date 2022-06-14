using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {

        //public string localPath = TestContext.CurrentContext.TestDirectory + @"\config_inc.php";
        [OneTimeSetUp] //замена файла
        public void setUpConfig()
        {
            string localPath = TestContext.CurrentContext.TestDirectory + @"\config_inc.php";
            app.Ftp.BackupFile("/config_inc.php"); //или /config_inc.php
            using (Stream localFile = File.Open(localPath, FileMode.Open)) //открытие на чтнеие файла
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            app.Registration.Register(account);
        }

        [OneTimeTearDown] //восстановление файла
        public void restorConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
