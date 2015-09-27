using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Catalog
{
    internal class MemberList : Base.Base<Entity.Catalog.MemberList>
    {
        public MemberList(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
