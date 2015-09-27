using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GOLDEPUS.Entity.Finance
{
    [Table("RevenueItem")]
    public class RevenueItem : Base.BaseEntity
    {
        public double Amount { get; set; }
        
        public Revenues Revenues { get; set; }
    }
}
