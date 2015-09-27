using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GOLDEPUS.Entity.Finance
{
    [Table("MemberRevenues")]
    public class MemberRevenues : Base.BaseEntity
    {
        public User.Account Account { get; set; }
        
        public Revenues Revenues { get; set; }
    }
}
