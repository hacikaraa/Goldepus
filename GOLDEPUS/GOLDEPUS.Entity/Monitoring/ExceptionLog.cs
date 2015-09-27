using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Monitoring
{
    [Table("ExceptionLog")]
    public class ExceptionLog : Base.LogBase
    {
        public string ExceptionMessage { get; set; }

        public string ExceptionCode { get; set; }

        public string Exception { get; set; }
    }
}
