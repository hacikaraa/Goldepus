using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Catalog
{
    [Table("ListColumns")]
    public class ListColumns : Base.BaseEntity
    {
        public Framework.Label Label { get; set; }

        public virtual ICollection<Catalog.Column> Column { get; set; }
        
        public List List { get; set; }
    }
}
