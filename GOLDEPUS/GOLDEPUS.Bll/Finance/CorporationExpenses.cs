using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Finance
{
    internal class CorporationExpenses : Base.Base<Entity.Finance.CorporationExpenses>
    {
        public CorporationExpenses(Bll.Facede Application) : base(Application) { }
    }
}
