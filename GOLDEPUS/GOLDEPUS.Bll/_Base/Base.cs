using System;


namespace GOLDEPUS.Base
{
    internal abstract class Base<T> where T : class
    {
        public Bll.Facede Application { get; private set; }

        public Base(Bll.Facede Application)
        {
            this.Application = Application;
        }

        public Entity.DBEngine.UnitOfWorks DataProcess { get { return this.Application.DataProcess; } }
        
        private Entity.DBEngine.Repository<T> dbaction;
        public Entity.DBEngine.Repository<T> DBAction
        {
            get
            {
                if (this.dbaction == null) this.dbaction = this.Application.DataProcess.RepositoryFactory<T>();
                return this.dbaction;
            }
        }

        public void CreateExceptionLog(Exception ex)
        {
            Entity.Monitoring.ExceptionLog exlog = new Entity.Monitoring.ExceptionLog();
            exlog.Exception = ex.ToString();
            exlog.ExceptionMessage = ex.Message;
            exlog.InnerException = (ex.InnerException != null) ? ex.InnerException.ToString() : "NULL";
            exlog.EntityValue = (ex.Data != null) ? ex.Data.ToString() : "NULL";
            exlog.ExecuteEntity = this.GetType().FullName;
            exlog.ExecuteType = "BLL";
            exlog.AccountId = (this.Application.DataProcess.HasSession) ? this.Application.DataProcess.ActiveUser.Id : 0;
            Application.Monitoring.CreateExceptionLog(exlog);
        }

    }
}
