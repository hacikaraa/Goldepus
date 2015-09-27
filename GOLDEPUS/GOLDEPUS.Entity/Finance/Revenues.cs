using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GOLDEPUS.Entity.Finance
{
    [Table("Revenues")]
    public class Revenues : Base.BaseEntity
    {
        public ICollection<RevenueItem> RevenueItems { get; set; }
    }
}
