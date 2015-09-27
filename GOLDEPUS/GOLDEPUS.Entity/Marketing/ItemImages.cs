using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Entity.Marketing
{
    [Table("ItemImages")]
    public class ItemImages : Base.BaseEntity
    {
        public string ImagePath { get; set; }

        public string ImageBase64 { get; set; }
    }
}
