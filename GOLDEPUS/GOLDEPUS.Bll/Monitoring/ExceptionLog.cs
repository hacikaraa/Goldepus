using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Monitoring
{
    internal class ExceptionLog : Base.Base<Entity.Monitoring.ExceptionLog>
    {
        public ExceptionLog(Entity.DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }

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
