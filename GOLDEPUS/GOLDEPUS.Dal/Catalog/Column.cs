using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Catalog
{
    internal class Column : Base.Base<Entity.Catalog.Column>
    {
        public Column(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
