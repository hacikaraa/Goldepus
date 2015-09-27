using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Formal
{
    internal class CorporationMember : Base.Base<Entity.Formal.CorporationMember>
    {
        public CorporationMember(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
