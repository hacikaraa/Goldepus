using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GOLDEPUS.Entity.Finance
{
    [Table("CorporationRevenues")]
    public class CorporationRevenues : Base.BaseEntity
    {
        public Formal.Corporation Corporation { get; set; }
        
        public Revenues Revenues { get; set; }
    }
}
