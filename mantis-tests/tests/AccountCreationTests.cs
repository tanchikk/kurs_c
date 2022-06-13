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
        [OneTimeSetUp] //замена файла
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config/config_inc.php"); //или /config_inc.php
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open)) //открытие на чтнеие файла
            {
                app.Ftp.Upload("/config/config_inc.php", localFile);
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
            app.Ftp.RestoreBackupFile("/config/config_inc.php");
        }
    }
}
