using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData> //для сравнения списков
    {
        //private string name;
        //private string header = "";
        //private string footer = "";

        public GroupData(string name) //констурктор c name
        {
            Name = name;
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
            //или return Name.Equals(other.Name);
            return Name == other.Name; 
        }

        public override int GetHashCode() //для стандартных методов вшитых помечают словом override
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\nheader= " + Header + "\nfooter= " + Footer;
        }

        public int CompareTo(GroupData other) // 0- объект равны, - тек.объект меньше, чем переданный
        {
            if (Object.ReferenceEquals(other, null)) 
            {
                return 1; //тек.объект больше
            }
            return Name.CompareTo(other.Name); //сравнение Name групп
        }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }   

        public string Id { get; set; }
    }
}
