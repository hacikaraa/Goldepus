using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace GOLDEPUS.Entity.Catalog
{
    [Table("CorporationList")]
   public  class CorporationList : Base.BaseEntity
    {
        public Formal.Corporation Corporation { get; set; }
        
        public List List { get; set; }
    }
}
