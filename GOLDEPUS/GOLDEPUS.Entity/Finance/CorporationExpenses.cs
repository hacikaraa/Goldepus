using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Finance
{
    [Table("CorporationExpenses")]
    public class CorporationExpenses : Base.BaseEntity
    {
        public Formal.Corporation Corporation { get; set; }
        
        public Expenses Expenses { get; set; }
    }
}
