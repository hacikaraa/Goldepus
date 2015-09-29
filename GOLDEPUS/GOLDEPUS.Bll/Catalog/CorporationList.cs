using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Catalog
{
    internal class CorporationList : Base.Base<Entity.Catalog.CorporationList>
    {
        public CorporationList(Entity.DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
