using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        /*private string firstname;
        private string lastname;
        private string middlename = "";
        private string nickname = "";
        private string photo = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string ayear = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";*/
        private string allPhones;
        private string allEmail;
        private string allContactDetails;

        public ContactData() //констурктор
        {
        }

        public ContactData(string firstname, string lastname) //констурктор
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other) //метод для сравнения списков
        {
            if (object.ReferenceEquals(other, null)) //сравнение с нулл
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))  //сравнение с самим собой
            {
                return true;
            }            
            return Lastname == other.Lastname && Firstname == other.Firstname;
        }

        public override int GetHashCode() //для стандартных методов вшитых помечают словом override
        {
            return Lastname.GetHashCode() + Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return Lastname + Firstname;
        }

        /*public int CompareTo(ContactData other) // 0- объект равны, -1 тек.объект меньше, чем переданный
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1; //тек.объект больше
            }
            //return Lastname.CompareTo(other.Lastname) ^ Firstname.CompareTo(other.Firstname);

            if (Lastname.CompareTo(other.Lastname) == 0 && Firstname.CompareTo(other.Firstname) == 0)
            {
                return 0;
            }
            return -1;
        }*/

        public int CompareTo(ContactData other) // 0- объект равны, -1 тек.объект меньше, чем переданный
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1; //тек.объект больше
            }
            //return Lastname.CompareTo(other.Lastname) ^ Firstname.CompareTo(other.Firstname);

            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }

            /*if (Lastname.CompareTo(other.Lastname) == 0)
            {
                if (Firstname.CompareTo(other.Firstname) == 0)
                {
                    return 0;
                }
                return 1;
            }
            return -1;
            if (Lastname.CompareTo(other.Lastname) == 0 && Firstname.CompareTo(other.Firstname) == 0)
            {
                return 0;
            }
            return -1;*/
        }

        public string Firstname { get; set; }
        
        public string Lastname { get; set; }       

        public string Middlename { get; set; }

        public string Nickname { get; set; }
        
        public string Photo { get; set; }
 
        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Byear { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        [XmlIgnore, JsonIgnore]
        public string Id { get; set; }

        [XmlIgnore, JsonIgnore]
        public string AllContactDetails 
        {
             get
             {
                if (allContactDetails != null)
                {
                    return allContactDetails;
                }
                else
                {
                    string allDetails = (CleanUpDetails(GetContacts(Firstname, Middlename, Lastname, Nickname, Title, Company, Address))
                        + CleanUpDetails(GetPhones(Home, Mobile, Work, Fax))
                        + CleanUpDetails(GetEmail(Email, Email2, Email3, Homepage))).Trim();
                    return allDetails;
                }
            }
            set
            {
                allContactDetails = value;
            } 
        }

        [XmlIgnore, JsonIgnore]
        public string AllPhones 
        { 
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Phone2)).Trim(); //склеивание 3 строки в одну + почистили от лишних символов
                                                                                     //Trim() удаляет у строк вначале и в конце лишнее
                }
            }

            set
            {
                allPhones = value;
            }
        }

        [XmlIgnore, JsonIgnore]
        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUpRN(Email) + CleanUpRN(Email2) + CleanUpRN(Email3)).Trim();  //Trim() удаляет у строк вначале и в конце лишнее
                }
            }

            set
            {
                allEmail = value;
            }
        }

        private string CleanUp(string phone) //чистим от лишних символов телефон
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[- ()]", "") + "\r\n"; // (в чем заменяем, шаблон, на что заменяем)
            //или так phone.Replace(" ", "").Replace("-","").Replace("(", "").Replace(")", "") + "\r\n"; //Replace("-","") вместо - делаем пустую строку
        }

        private string CleanUpRN(string email) //чистим от лишних символов телефон
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ ]", "") + "\r\n";
        }

        private string GetNameFull(string firstname, string middlename, string lastname)
        {
            string bufer = "";
            if (firstname != null && firstname != "")
            {
                bufer = Firstname + " ";
            }
            if (middlename != null && middlename != "")
            {
                bufer = bufer + Middlename + " ";
            }
            if (lastname != null && lastname != "")
            {
                bufer = bufer + Lastname + " ";
            }
            return bufer.Trim();
        }

        private string GetContacts(string firstname, string middlename, string lastname, string nickname, string title, string company, string address)
        {
            return CleanUpDetails(GetNameFull(firstname, middlename, lastname))
                        + CleanUpDetails(nickname)
                        + CleanUpDetails(title)
                        + CleanUpDetails(company)
                        + CleanUpDetails(address);
        }

        private string GetPhones(string home, string mobile, string work, string fax)
        {
            string bufer = "";
            if (home != null && home != "")
            {
                bufer = bufer + "H: " + Home + "\r\n";
            }
            if (mobile != null && mobile != "")
            {
                bufer = bufer + "M: " + Mobile + "\r\n";
            }
            if (work != null && work != "")
            {
                bufer = bufer + "W: " + Work + "\r\n";
            }
            if (fax != null && fax != "")
            {
                bufer = bufer + "F: " + Fax  + "\r\n";
            }
            return bufer;
        }

        private string GetEmail(string email, string email2, string email3, string homepage)
        {
            string bufer = "";
            if (email != null && email != "")
            {
                bufer = bufer + email + "\r\n";
            }
            if (email2 != null && email2 != "")
            {
                bufer = bufer + email2 + "\r\n";
            }
            if (email3 != null && email3 != "")
            {
                bufer = bufer + email3 + "\r\n";
            }
            if (homepage != null && homepage != "")
            {
                bufer = bufer + "Homepage:" + "\r\n" + homepage + "\r\n";
            }
            return bufer;
        }

        private string GetPhone2(string phone2)
        {
            if (phone2 == null || phone2 == "")
            {
                return "";
            }

            return "P: " + Phone2 + "\r\n" + "\r\n";
        }

        private string CleanUpDetails(string detail) //чистим от лишних символов телефон
        {
            if (detail == null || detail == "")
            {
                return "";
            }
            return detail + "\r\n";
        }

        private string CleanUpDetailsTwo(string detail) //чистим от лишних символов телефон
        {
            if (detail == null || detail == "")
            {
                return "";
            }
            return detail + "\r\n" + "\r\n";
        }

        /* public string FullYears()
         {
             int age = 0;
             var cultureInfo = new CultureInfo("en-EN");
             string date = $"{Bday} {Bmonth} {Byear}";
             var datatime = DateTime.Parse(date, cultureInfo);
             if (DateTime.Now.Month > datatime.Month || DateTime.Now.Month == datatime.Month && DateTime.Now.Day >= datatime.Day)
             {
                 age = DateTime.Now.Year - datatime.Year;
             }
             else
             {
                 age = DateTime.Now.Year - datatime.Year - 1;
             }        
             return $" ({age})";
         }*/

        /*public string FullYearsAnnyvercity()
        {           
            int age = 0;
            var cultureInfo = new CultureInfo("en-EN");
            string date = $"{Aday} {Amonth} {Ayear}";
            var datatime = DateTime.Parse(date, cultureInfo);
            if (DateTime.Now.Month > datatime.Month || DateTime.Now.Month == datatime.Month && DateTime.Now.Day >= datatime.Day)
            {
                age = DateTime.Now.Year - datatime.Year;
            }
            else
            {
                age = DateTime.Now.Year - datatime.Year - 1;
            }           
            return $" ({age})";
        }*/
    }
}
