using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Catalog
{
    internal class List : Base.Base<Entity.Catalog.List>
    {
        public List(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
