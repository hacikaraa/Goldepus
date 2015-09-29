using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Finance
{
    internal class ExpenseItem : Base.Base<Entity.Finance.ExpenseItem>
    {
        public ExpenseItem(Entity.DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
