using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Finance
{
    internal class ExpenseItem : Base.Base<Entity.Finance.ExpenseItem>
    {
        public ExpenseItem(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
