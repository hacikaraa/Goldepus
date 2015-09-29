using System;


namespace GOLDEPUS.Base
{
    internal abstract class Base<T> where T : class
    {
        private Bll.Facede bll;
        public Bll.Facede Bll
        {
            get
            {
                if (bll == null) bll = new Bll.Facede(DataProcess);
                return bll;
            }
        }
        
        public Entity.DBEngine.UnitOfWorks DataProcess { get; private set; }

        public Base(Entity.DBEngine.UnitOfWorks DataProcess)
        {
            this.DataProcess = DataProcess;
        }

        private Entity.DBEngine.Repository<T> dbaction;
        public Entity.DBEngine.Repository<T> DBAction
        {
            get
            {
                if (this.dbaction == null) this.dbaction = this.DataProcess.RepositoryFactory<T>();
                return this.dbaction;
            }
        }

        public void CreateExceptionLog(Exception ex)
        {
            Entity.Monitoring.ExceptionLog exlog = new Entity.Monitoring.ExceptionLog();
            exlog.ExceptionMessage = ex.Message;
            exlog.ExecuteEntity = this.GetType().FullName;
            exlog.EntityValue = "";
            exlog.ExecuteType = "";
            Bll.Monitoring.CreateExceptionLog(exlog);
        }



    }
}
