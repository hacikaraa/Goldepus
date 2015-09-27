using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeYapisi.Models
{
    public class NoteModel
    {
        private string sNoteText;
        private string sNoteTitle;

        [StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır!")]
        [Display(Name = "Not Başlığı")]
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [DataType(DataType.Text)]
        public string NoteTitle
        {
            get { return sNoteTitle; }
            set { sNoteTitle = value; }
        }

        [Display(Name = "Notunuz")]
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [DataType(DataType.MultilineText)]
        public string NoteText
        {
            get { return sNoteText; }
            set { sNoteText = value; }
        }
    }
}