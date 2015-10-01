using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Entity.DBEngine
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext context;
        private DbSet<T> dbSet;
        private UnitOfWorks DataProcess;
        public Repository(DataContext Context, UnitOfWorks DataProcess)
        {
            context = Context;
            dbSet = context.Set<T>();
            this.DataProcess = DataProcess;
        }

        public virtual T FindById(object EntityId)
        {
            return dbSet.Find(EntityId);
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {

            if (Filter != null)
                return dbSet.Where(Filter);
            return dbSet;
        }

        public virtual void Insert(ref T entity)
        {
            if (entity.GetType().GetProperty("GetEntityType").GetValue(entity, new object[] { }).ToString().Equals("Entity"))
            {
                if (this.DataProcess.HasSession)
                {
                    entity.GetType().GetProperty("UserCreated").SetValue(entity, this.DataProcess.ActiveUser.Id);
                    entity.GetType().GetProperty("UserModified").SetValue(entity, this.DataProcess.ActiveUser.Id);
                }
                entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
                entity.GetType().GetProperty("ModifiedDate").SetValue(entity, DateTime.Now);
            }
            else if (entity.GetType().GetProperty("GetEntityType").GetValue(entity, new object[] { }).ToString().Equals("Log"))
            {
                entity.GetType().GetProperty("LogTime").SetValue(entity, DateTime.Now);
                if (this.DataProcess.HasSession)
                {
                    entity.GetType().GetProperty("AccountId").SetValue(entity, this.DataProcess.ActiveUser.Id);
                }
            }

            dbSet.Add(entity);
        }

        public virtual void Update(ref T entityToUpdate)
        {
            if (entityToUpdate.GetType().GetProperty("GetEntityType").GetValue(entityToUpdate, new object[] { }).ToString().Equals("Entity"))
            {
                if (this.DataProcess.HasSession)
                {
                    entityToUpdate.GetType().GetProperty("UserModified").SetValue(entityToUpdate, this.DataProcess.ActiveUser.Id);
                }
                entityToUpdate.GetType().GetProperty("ModifiedDate").SetValue(entityToUpdate, DateTime.Now);
            }

            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(object EntityId)
        {
            T entityToDelete = dbSet.Find(EntityId);
            Delete(entityToDelete);
        }

        public virtual void Delete(T Entity)
        {
            if (context.Entry(Entity).State == EntityState.Detached)
                dbSet.Attach(Entity);
            dbSet.Remove(Entity);
        }
    }
}
