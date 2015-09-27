using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Finance
{
    internal class MemberExpenses : Base.Base<Entity.Finance.MemberExpenses>
    {
        public MemberExpenses(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
