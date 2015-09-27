using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Finance
{
    [Table("MemberExpenses")]
    public class MemberExpenses : Base.BaseEntity
    {
        public User.Account Account { get; set; }
        
        public Expenses Expenses { get; set; }
    }
}
