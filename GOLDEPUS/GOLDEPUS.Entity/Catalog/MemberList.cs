using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace GOLDEPUS.Entity.Catalog
{
    [Table("MemberList")]
    public class MemberList : Base.BaseEntity
    {
        public User.Account Account { get; set; }
        
        public List List { get; set; }

    }
}
