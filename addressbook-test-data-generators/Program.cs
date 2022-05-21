using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WebAddressbookTests; //юзинг с основным пространством из др проекта

namespace addressbook_test_data_generators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]); //передаем кол-вопараметров, которые хотим сгенерить
            StreamWriter writer = new StreamWriter(args[1]); 
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(String.Format("${0},${1},${2}", //3 строки через запятую, затем передаем 3 параметра:
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10))); //WriteLine - строка завершается переводом строки
            } //TestBase.GenerateRandomString(10); - генерируем 10 групп
            writer.Close(); //закрыть writer, чтобы данные не потерялись в файле
        }
    }
}
