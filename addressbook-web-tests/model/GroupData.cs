using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData> //для сравнения списков
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name) //констурктор c name
        {
            this.name = name;
        }

        public bool Equals(GroupData other) //метод для сравнения списков
        {
            if (object.ReferenceEquals(other, null)) //сравнение с нулл
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))  //сравнение с самим собой
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode() //для стандартных методов вшитых помечают словом override
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name;
        }

        public int CompareTo(GroupData other) // 0- объект равны, - тек.объект меньше, чем переданный
        {
            if (Object.ReferenceEquals(other, null)) 
            {
                return 1; //тек.объект больше
            }
            return Name.CompareTo(other.Name); //сравнение Name групп
        }

        public string Name 
        {
            get
            {
                return name; 
            } 

            set
            {
                name = value;              
            }
        }
        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
            }
        }
        public string Footer
        {
            get
            {
                return footer;
            }

            set
            {
                footer = value;
            }
        }       
    }
}
