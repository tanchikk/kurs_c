using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
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
        private string notes = "";


        public ContactData(string firstname, string lastname) //констурктор
        {
            this.firstname = firstname;
            this.lastname = lastname;
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

        public string Firstname
        {
            get 
            { 
                return firstname; 
            }
            
            set
            {
                this.firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                this.lastname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }

            set
            {
                this.middlename = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                this.nickname = value;
            }
        }

        public string Photo
        {
            get
            {
                return photo;
            }

            set
            {
                this.photo = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                this.title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                this.company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                this.address = value;
            }
        }

        public string Home
        {
            get
            {
                return home;
            }

            set
            {
                this.home = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                this.mobile = value;
            }
        }

        public string Work
        {
            get
            {
                return work;
            }

            set
            {
                this.work = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                this.fax = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                this.email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }

            set
            {
                this.email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }

            set
            {
                this.email3 = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }

            set
            {
                this.homepage = value;
            }
        }

        public string Bday
        {
            get
            {
                return bday;
            }

            set
            {
                this.bday = value;
            }
        }
        public string Bmonth
        {
            get
            {
                return bmonth;
            }

            set
            {
                this.bmonth = value;
            }
        }

        public string Byear
        {
            get
            {
                return byear;
            }

            set
            {
                this.byear = value;
            }
        }

        public string Ayear
        {
            get
            {
                return ayear;
            }

            set
            {
                this.ayear = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }

            set
            {
                this.address2 = value;
            }
        }
        public string Phone2
        {
            get
            {
                return phone2;
            }

            set
            {
                this.phone2 = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                this.notes = value;
            }
        }
    }
}
