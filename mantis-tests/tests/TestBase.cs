using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class TestBase //класс для наследования (поля и классы public / protected для доступа к ним)
    {
        protected ApplicationManager app;

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance(); //сслыаемся на переменную в классе
        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {

            //получение числа от 0 до максимального
            int l = Convert.ToInt32(rnd.NextDouble() * max); //NextDouble() генерация числа от 0 до 1, Convert.ToInt32 - округление
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 10)));
            }
            return builder.ToString();
        }
    }
}
