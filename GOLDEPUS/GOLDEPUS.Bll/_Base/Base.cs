using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Base
{
    internal abstract class Base
    {
        private Bll.Facede bll;
        public Bll.Facede Bll
        {
            get
            {
                if (bll == null) bll = new Bll.Facede();
                return bll;
            }
        }

        private Dal.Facede dal;
        public Dal.Facede Dal
        {
            get
            {
                if (dal == null) dal = new Dal.Facede();
                return dal;
            }
        }
    }
}
