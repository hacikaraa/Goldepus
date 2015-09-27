using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Entity.Marketing
{
    [Table("ItemCampaign")]
    public class ItemCampaign : Base.BaseEntity
    {
        public Campaign Campaign { get; set; }

        public Item Item { get; set; }
    }
}
