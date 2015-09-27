using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Catalog
{
    [Table("ListItem")]
    public class ListItem : Base.BaseEntity
    {     
        public List List { get; set; }

        public virtual ICollection<Column> Columns { get; set; }
    }
}