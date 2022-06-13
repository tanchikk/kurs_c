﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.FtpClient;

namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient client;
        public FtpHelper(ApplicationManager manager) : base(manager) {
            client = new FtpClient();
            client.Host = "localhost";
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis"); //логин и пароль
            client.Connect(); //соединение устанвлено
        }

        public void BackupFile(String path) //конфиг существующий припрятать для восстановления
        {
            String backupPath = path + ".bak";
            if (client.FileExists(backupPath)) //если файл есть, то новый бэкап не делаем
            {
                return;
            }
            client.Rename(path, backupPath);
        }

        public void RestoreBackupFile(String path) //восстановление конфига
        {
            String backupPath = path + ".bak";
            if (!client.FileExists(backupPath)) //если файла нет, то нечего восстанавливать
            {
                return;
            }
            if (client.FileExists(path)) //если файл есть, то удаляем его
            {
                client.DeleteFile(path);
            }
            client.Rename(backupPath, path); //восстановление
        }

        public void Upload(String path, Stream localFile)
        {
            if (client.FileExists(path)) //если файл есть, то удаляем его
            {
                client.DeleteFile(path);
            }

            using (Stream ftpStream = client.OpenWrite(path)) //читаем файл и записываем его
            {
                byte[] buffer = new byte[8 * 1024];
                int count = localFile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
