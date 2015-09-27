using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Catalog
{
    [Table("Column")]
    public class Column : Base.BaseEntity
    {
        public ListItem ListItem { get; set; }

        public ListColumns ListColumn { get; set; }
        
        public string Value { get; set; }
    }
}