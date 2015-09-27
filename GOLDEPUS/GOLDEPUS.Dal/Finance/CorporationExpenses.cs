using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Finance
{
    internal class CorporationExpenses : Base.Base<Entity.Finance.CorporationExpenses>
    {
        public CorporationExpenses(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
