using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Finance
{
    internal class Revenues : Base.Base<Entity.Finance.Revenues>
    {
        public Revenues(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
