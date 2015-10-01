using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Monitoring
{
    internal class ExceptionLog : Base.Base<Entity.Monitoring.ExceptionLog>
    {
        public ExceptionLog(Bll.Facede Application) : base(Application) { }

        public void CreateLog(Entity.Monitoring.ExceptionLog exlog)
        {
            try
            {
                base.DBAction.Insert(ref exlog);
                DataProcess.Save();
            }
            catch (Exception)
            {; }
        }
    }
}
