using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Formal
{
    public class Facede
    {
        private Corporation corporation;
        private CorporationMember corporationMember;
        public Facede(Entity.DBEngine.UnitOfWorks DataProcess)
        {
            corporation = new Corporation(DataProcess);
            corporationMember = new CorporationMember(DataProcess);
        }
    }
}
