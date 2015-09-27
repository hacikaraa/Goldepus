using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.DBEngine
{
    internal interface IUnitOfWork : IDisposable
    {
        bool Save();
    }
}
