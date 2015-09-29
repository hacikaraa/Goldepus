using System;

namespace GOLDEPUS.Entity.DBEngine
{
    public class UnitOfWorks : IUnitOfWork
    {
        private DataContext context;
        private bool disposed = false;

        public UnitOfWorks(DataContext context)
        {
            this.context = context;
        }
        
        public Repository<T> RepositoryFactory<T>() where T : class
        {
            return new Repository<T>(context);
        }

        public bool Save()
        {
            if (context.Database.Connection.State == System.Data.ConnectionState.Closed)
                context.Database.Connection.Open();
            var dbContextTransaction = context.Database.BeginTransaction();
            try
            {
                context.SaveChanges();
                dbContextTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                dbContextTransaction.Rollback();
                return false;
            }
            finally
            {
                context.Database.Connection.Close();
                //this.Dispose();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }      
    }
}
