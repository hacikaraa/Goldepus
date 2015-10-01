using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.User
{
    [Table("Account")]
    public class Account : Base.BaseEntity
    {
        [StringLength(32,MinimumLength = 4)]
        public string AccountName { get; set; }

        [StringLength(32)]
        [Column(TypeName = "char")]
        public string AccountPasword { get; set; }

        [StringLength(32)]
        public string Email { get; set; }

        public string ImagePath { get; set; }

        public string PhoneNumber { get; set; }

        public string WebSite { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Finance.MemberRevenues> MemberRevenues { get; set; }

        public virtual ICollection<Finance.MemberExpenses> MemberExpenses { get; set; }

        public virtual ICollection<Catalog.MemberList> MemberListes { get; set; }

        public virtual ICollection<Formal.Corporation> Corporations { get; set; }

    }
}
