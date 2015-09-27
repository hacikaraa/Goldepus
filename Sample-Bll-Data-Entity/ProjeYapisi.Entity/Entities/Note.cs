using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProjeYapisi.Entity.Entities
{
    [Table("tblNote")]
    public class Note:BaseEntity
    {
        private string sNoteText;
        private string sNoteTitle;
        private int iMemberId;

        public int MemberId
        {
            get { return iMemberId; }
            set { iMemberId = value; }
        }
        
        [ForeignKey("MemberId")]
        public virtual Member MemberEntity { get; set; }

        [StringLength(50), Required]
        public string NoteTitle
        {
            get { return sNoteTitle; }
            set { sNoteTitle = value; }
        }
        
        [Required]
        public string NoteText
        {
            get { return sNoteText; }
            set { sNoteText = value; }
        }
    }
}
