using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Finance
{
    internal class RevenueItem : Base.Base<Entity.Finance.RevenueItem>
    {
        public RevenueItem(Entity.DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
