using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Finance
{
    internal class CorporationRevenues : Base.Base<Entity.Finance.CorporationRevenues>
    {
        public CorporationRevenues(Entity.DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
