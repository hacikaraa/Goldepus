using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Entity.Marketing
{
    [Table("ItemProperties")]
    public class ItemProperties : Base.BaseEntity
    {
        public Item Item { get; set; }

        public Framework.Label Label { get; set; }

        public object Value { get; set; }
    }
}
