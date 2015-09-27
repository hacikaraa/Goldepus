using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Finance
{
    [Table("Expenses")]
    public class Expenses : Base.BaseEntity
    {
        public ICollection<ExpenseItem> ExpenseItems { get; set; }
    }
}
