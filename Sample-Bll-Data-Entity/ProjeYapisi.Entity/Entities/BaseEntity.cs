using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjeYapisi.Entity.Entities
{
    public abstract class BaseEntity
    {
        private int iID;

        public int ID
        {
            get { return iID; }
            set { iID = value; }
        }
        
    }
}
