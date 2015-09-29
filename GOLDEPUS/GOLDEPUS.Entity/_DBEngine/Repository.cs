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
        public Repository(DataContext Context)
        {
            context = Context;
            dbSet = context.Set<T>();
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
            //Userlar için bir düzenleme yapılması gerekiyor.
            //entity.GetType().GetProperty("UserModified").SetValue(entity, 1);
            //entity.GetType().GetProperty("UserModified").SetValue(entity, 1);
            if (entity.GetType().GetProperty("CreatedDate") != null)
            {
                entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
                entity.GetType().GetProperty("ModifiedDate").SetValue(entity, DateTime.Now);
            }
            dbSet.Add(entity);
        }

        public virtual void Update(ref T entityToUpdate)
        {
            //Userlar için bir düzenleme yapılması gerekiyor.
            //entity.GetType().GetProperty("UserModified").SetValue(entity, 1);
            //entity.GetType().GetProperty("UserModified").SetValue(entity, 1);
            if (entityToUpdate.GetType().GetProperty("ModifiedDate") != null)
                entityToUpdate.GetType().GetProperty("ModifiedDate").SetValue(entityToUpdate, DateTime.Now);

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
