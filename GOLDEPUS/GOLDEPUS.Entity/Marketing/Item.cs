using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Entity.Marketing
{
    [Table("Item")]
    public class Item : Base.BaseEntity
    {


        public virtual ICollection<ItemImages> Images { get; set; }

        public virtual ICollection<ItemProperties> Properties { get; set; }

        public virtual ICollection<ItemGroups> Groups { get; set; }

        public virtual ICollection<ItemCampaign> Campaigns { get; set; }

    }
}
