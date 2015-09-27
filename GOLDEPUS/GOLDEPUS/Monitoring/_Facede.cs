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
        public Facede()
        {
            exceptionLog = new ExceptionLog();
            executeLog = new ExecuteLog();
            performanceLog = new PerformanceLog();
        }

        public void CreateExceptionLog(Entity.Monitoring.ExceptionLog exlog)
        {
            this.exceptionLog.CreateExceptionLog(exlog);
        }
    }
}
