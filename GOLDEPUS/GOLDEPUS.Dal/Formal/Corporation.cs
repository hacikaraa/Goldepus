using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Formal
{
    internal class Corporation : Base.Base<Entity.Formal.Corporation>
    {
        public Corporation(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
