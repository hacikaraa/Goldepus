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
        public Facede(Bll.Facede Application)
        {
            exceptionLog = new ExceptionLog(Application);
            executeLog = new ExecuteLog(Application);
            performanceLog = new PerformanceLog(Application);
        }

        public void CreateExceptionLog(Entity.Monitoring.ExceptionLog exlog)
        {
            this.exceptionLog.CreateLog(exlog);
        }
    }
}
