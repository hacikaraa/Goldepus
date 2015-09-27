using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Finance
{
    internal class MemberRevenues : Base.Base<Entity.Finance.MemberRevenues>
    {
        public MemberRevenues(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
