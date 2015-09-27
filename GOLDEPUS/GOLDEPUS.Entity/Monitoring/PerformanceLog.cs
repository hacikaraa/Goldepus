using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Monitoring
{
    [Table("PerformanceLog")]
    public class PerformanceLog : Base.LogBase
    {
        public DateTime StartActivity { get; set; }

        public DateTime FinishActivity { get; set; }
    }
}
