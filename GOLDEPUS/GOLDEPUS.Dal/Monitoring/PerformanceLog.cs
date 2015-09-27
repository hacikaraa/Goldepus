using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Monitoring
{
    internal class PerformanceLog : Base.Base<Entity.Monitoring.PerformanceLog>
    {
        public PerformanceLog(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
