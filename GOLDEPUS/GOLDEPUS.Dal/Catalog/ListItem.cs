using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Catalog
{
    internal class ListItem : Base.Base<Entity.Catalog.ListItem>
    {
        public ListItem(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
