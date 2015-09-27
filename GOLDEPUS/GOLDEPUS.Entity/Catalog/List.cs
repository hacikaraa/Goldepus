using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Catalog
{
    [Table("List")]
    public class List : Base.BaseEntity
    {     
        public virtual ICollection<ListItem> ListItems { get; set; }
    }
}
