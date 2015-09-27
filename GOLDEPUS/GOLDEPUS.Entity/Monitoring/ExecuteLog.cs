using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Monitoring
{
    [Table("ExecuteLog")]
    public class ExecuteLog : Base.LogBase
    {
        public DateTime CreatedDate { get; set; }
    }
}
