using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Monitoring
{
    internal class ExceptionLog : Base.Base
    {
        public void CreateExceptionLog(Entity.Monitoring.ExceptionLog exlog)
        {
            base.Dal.Monitoring.CreateExceptionLog(exlog);
        }
    }
}
