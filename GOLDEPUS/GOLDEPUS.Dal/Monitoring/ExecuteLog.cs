using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Monitoring
{
    internal class ExecuteLog : Base.Base<Entity.Monitoring.ExecuteLog>
    {
        public ExecuteLog(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
