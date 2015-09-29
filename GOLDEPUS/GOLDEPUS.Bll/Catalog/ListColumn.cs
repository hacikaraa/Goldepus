using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Catalog
{
    internal class ListColumn : Base.Base<Entity.Catalog.ListColumns>
    {
        public ListColumn(Entity.DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
