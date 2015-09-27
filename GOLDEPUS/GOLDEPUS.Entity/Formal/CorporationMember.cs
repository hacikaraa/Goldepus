using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Formal
{
    [Table("CorporationMember")]
    public  class CorporationMember : Base.BaseEntity
    {
        public Corporation Corporation { get; set; }
        
        public User.Account Account { get; set; }


    }
}
