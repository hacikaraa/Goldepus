﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Finance
{
    internal class Expenses : Base.Base<Entity.Finance.Expenses>
    {
        public Expenses(Entity.DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }
    }
}
