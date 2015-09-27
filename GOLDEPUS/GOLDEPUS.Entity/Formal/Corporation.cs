using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Formal
{
    [Table("Corporation")]
    public class Corporation : Base.BaseEntity
    {
        public virtual ICollection<Catalog.CorporationList> Lists { get; set; }

        public virtual ICollection<CorporationMember> CorporationMembers { get; set; }

        public virtual ICollection<Finance.CorporationRevenues> CorporationRevenues { get; set; }

        public virtual ICollection<Finance.CorporationExpenses> CorporationExpenses { get; set; }
    }
}
