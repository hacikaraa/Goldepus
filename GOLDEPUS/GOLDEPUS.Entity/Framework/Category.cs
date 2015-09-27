using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Framework
{
    [Table("Category")]
    public class Category : Base.BaseEntity
    {
        public Category BaseCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }

        public virtual ICollection<Label> Labels { get; set; }
    }
}