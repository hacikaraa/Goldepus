using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Finance
{
    internal class Expenses : Base.Base<Entity.Finance.Expenses>
    {
        public Expenses(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
