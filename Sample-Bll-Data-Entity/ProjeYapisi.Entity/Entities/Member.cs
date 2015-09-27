using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProjeYapisi.Entity.Entities
{
    [Table("tblMember")]
    public class Member:BaseEntity
    {
        private string sName;
        private string sPassword;
        private string sEmail;
        private bool bMemberStatus;

        [Required]
        public bool MemberStatus
        {
            get { return bMemberStatus; }
            set { bMemberStatus = value; }
        }
        
        [StringLength(50), Required]
        public string Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }

        [StringLength(50), Required]
        public string Password
        {
            get { return sPassword; }
            set { sPassword = value; }
        }

        [StringLength(50), Required]
        public string Name
        {
            get { return sName; }
            set { sName = value; }
        }

        public virtual List<Note> Student { get; set; }
    }
}
