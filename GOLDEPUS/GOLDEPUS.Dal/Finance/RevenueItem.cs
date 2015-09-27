using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Finance
{
    internal class RevenueItem : Base.Base<Entity.Finance.RevenueItem>
    {
        public RevenueItem(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
