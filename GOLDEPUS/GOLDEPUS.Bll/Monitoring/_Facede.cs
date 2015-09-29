using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Monitoring
{
    public class Facede
    {
        private ExceptionLog exceptionLog;
        private ExecuteLog executeLog;
        private PerformanceLog performanceLog;
        public Facede(Entity.DBEngine.UnitOfWorks DataProcess)
        {
            exceptionLog = new ExceptionLog(DataProcess);
            executeLog = new ExecuteLog(DataProcess);
            performanceLog = new PerformanceLog(DataProcess);
        }

        public void CreateExceptionLog(Entity.Monitoring.ExceptionLog exlog)
        {
            this.exceptionLog.CreateLog(exlog);
        }
    }
}
