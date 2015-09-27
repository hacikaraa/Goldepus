using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Catalog
{
    internal class CorporationList : Base.Base<Entity.Catalog.CorporationList>
    {
        public CorporationList(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
