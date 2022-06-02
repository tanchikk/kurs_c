using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation
    {
        [Column("group_id")]
        public string GroupId { get; set; }

        [Column("id")]
        public string ContactId { get; set; }
    }
}