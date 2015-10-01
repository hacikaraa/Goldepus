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
        public Facede(Bll.Facede Application)
        {
            corporation = new Corporation(Application);
            corporationMember = new CorporationMember(Application);
        }
    }
}
