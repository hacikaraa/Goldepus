using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Base
{
    internal abstract class Base<T> where T : class
    {
        public DBEngine.UnitOfWorks DataProcess
        {
            get;private set;
        }
        public Base(DBEngine.UnitOfWorks DataProcess)
        {
            this.DataProcess = DataProcess;
        }

        private Dal.Facede dal;
        public Dal.Facede Dal
        {
            get
            {
                if (this.dal == null) this.dal = new Facede(this.DataProcess);
                return this.dal;
            }
        }

        private DBEngine.Repository<T> reponsitory;
        public DBEngine.Repository<T> Reponsitory
        {
            get
            {
                if(this.reponsitory == null) this.reponsitory = this.DataProcess.RepositoryFactory<T>();
                return this.reponsitory;
            }
        }

        public void CreateExceptionLog(Exception ex)
        {
            Entity.Monitoring.ExceptionLog exlog = new Entity.Monitoring.ExceptionLog();
            exlog.ExceptionMessage = ex.Message;
            exlog.ExecuteEntity = this.GetType().FullName;
            exlog.EntityValue = "";
            exlog.ExecuteType = "";
            Dal.Monitoring.CreateExceptionLog(exlog);
        }


    }
}
