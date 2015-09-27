using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEPUS.Entity.Base
{
    public class LogBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; protected set; }

        public int AccountId { get; set; }

        public string ExecuteEntity { get; set; }

        public string ExecuteType { get; set; }

        public string EntityValue { get; set; }
    }
}
