using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Entity.Marketing
{
    [Table("ItemGroups")]
    public class ItemGroups : Base.BaseEntity
    {
        public Catalog.Groups Group { get; set; }

        public Item Item { get; set; }
        
    }
}
