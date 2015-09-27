using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjeYapisi.Dal.Context;

namespace ProjeYapisi.Dal.EntityFramework
{
    public abstract class EfBaseDal
    {
        private MemberContext oMemberContext;

        public MemberContext MemberContext
        {
            get 
            {
                if (oMemberContext == null)
                {
                    oMemberContext = new MemberContext(); oMemberContext.Database.CreateIfNotExists();
                }
                return oMemberContext; 
            }
        }
        
    }
}
