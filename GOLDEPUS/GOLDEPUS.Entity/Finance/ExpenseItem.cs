using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Finance
{
    [Table("ExpenseItem")]
    public class ExpenseItem : Base.BaseEntity
    {
        public double Amount { get; set; }
        
        public Expenses Expenses { get; set; }

    }
}
