using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WebAddressbookTests; //юзинг с основным пространством из др проекта
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]); //передаем кол-вопараметров, которые хотим сгенерить
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();

            if (type == "groups")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10) //WriteLine - строка завершается переводом строки
                    });
                    /*writer.WriteLine(String.Format("${0},${1},${2}", //3 строки через запятую, затем передаем 3 параметра:
                        TestBase.GenerateRandomString(10),
                        TestBase.GenerateRandomString(10),
                        TestBase.GenerateRandomString(10)));*/
                }
            }
            else if (type == "contacts")
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomStringContact(10), TestBase.GenerateRandomStringContact(10)) 
                    {
                        Middlename = TestBase.GenerateRandomStringContact(10),
                        Nickname = TestBase.GenerateRandomStringContact(10),
                        //Title = TestBase.GenerateRandomStringContact(10),
                        //Company = TestBase.GenerateRandomStringContact(10),
                        Address = TestBase.GenerateRandomStringContact(10),
                        Home = TestBase.GenerateRandomStringContact(10),
                        Mobile = TestBase.GenerateRandomStringContact(10),
                        Work = TestBase.GenerateRandomStringContact(10),
                        //Fax = TestBase.GenerateRandomStringContact(10),
                        Email = TestBase.GenerateRandomStringContact(10),
                        Email2 = TestBase.GenerateRandomStringContact(10),
                        Email3 = TestBase.GenerateRandomStringContact(10),
                        Homepage = TestBase.GenerateRandomStringContact(10)
                        //Address2 = TestBase.GenerateRandomStringContact(10),
                        //Phone2 = TestBase.GenerateRandomStringContact(10),
                        //Notes = TestBase.GenerateRandomStringContact(10)
                    });
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized type " + type);
            }


            /*if (format == "csv")
            {
                writeGroupsToCsvFile(groups, writer);
            } */
             if (format == "xml")
            {
                if (type == "groups")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (type == "contacts")
                {
                    writeContactToXmlFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized type " + type);
                }
            }
            else if (format == "json")
            {
                if (type == "groups")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else if (type == "contacts")
                {
                    writeContactToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized type " + type);
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized format " + format);
            }
            
            writer.Close(); //закрыть writer, чтобы данные не потерялись в файле
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer) //groups что записываем, куда writer записываем
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer) 
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
