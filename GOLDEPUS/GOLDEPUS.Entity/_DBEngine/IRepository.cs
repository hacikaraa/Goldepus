using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Entity.DBEngine
{

    internal interface IRepository<T> where T : class
    {
        T FindById(object EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        void Insert(ref T Entity);
        void Update(ref T Entity);
        void Delete(object EntityId);
        void Delete(T Entity);

    }
}
