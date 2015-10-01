using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Finance
{
    internal class MemberExpenses : Base.Base<Entity.Finance.MemberExpenses>
    {
        public MemberExpenses(Bll.Facede Application) : base(Application) { }
    }
}
