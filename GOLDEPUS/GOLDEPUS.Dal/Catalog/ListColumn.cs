using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Catalog
{
    internal class ListColumn : Base.Base<Entity.Catalog.ListColumns>
    {
        public ListColumn(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
