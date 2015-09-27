using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Framework
{
    [Table("Label")]
    public class Label : Base.BaseEntity
    {
        public Category Category { get; set; }

    }
}
