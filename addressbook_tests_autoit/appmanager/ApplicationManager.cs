using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";

        private AutoItX3 aux;
        private GroupHelper groupHelper;

        public ApplicationManager() //инициализация
        {
            aux = new AutoItX3();
            aux.Run(@"C:\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW); //aux.SW_SHOW запуск ПО видимым
            aux.WinWait(WINTITLE); //подождать окно "Free Address Book"
            aux.WinActivate(WINTITLE); //активировать окно
            aux.WinWaitActive(WINTITLE);

            groupHelper = new GroupHelper(this);
        }

        public AutoItX3 Aux { 
            get { return aux; } 
        }

        public void Stop() //выйти по кнопке Exit
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510"); //клик по кнопке (окно в котором кнопка, текст кнопки, айди кнопки)
        } 

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
    }
}
