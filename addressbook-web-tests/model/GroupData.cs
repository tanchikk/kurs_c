using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData> //для сравнения списков
    {
        //private string name;
        //private string header = "";
        //private string footer = "";

        public GroupData() //констурктор пустой для файлов xml and json
        {
        }

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

        [Column(Name = "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList(); //чтение из БД
                //db.Close(); вызывается автоматом
            }
        }

        public List<ContactData> GetContacts() //находит контакты, которые пренадлежат группе
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList(); 
            }
        }
    }
}
