using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Base
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? UserCreated { get; set; }

        public int? UserModified { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual string GetEntityType { get { return "Entity"; } }

    }
}
