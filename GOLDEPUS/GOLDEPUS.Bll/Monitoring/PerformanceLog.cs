using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Monitoring
{
    internal class PerformanceLog : Base.Base<Entity.Monitoring.PerformanceLog>
    {
        public PerformanceLog(Entity.DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
