using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeYapisi.Bll;
using ProjeYapisi.Dal.EntityFramework;

namespace ProjeYapisi.Controllers
{
    public abstract class BaseController : Controller
    {
        private MemberManager oMemberManager;

        public MemberManager MemberManager
        {
            get 
            {
                if (oMemberManager == null)
                {
                    oMemberManager = new MemberManager(new EfMemberDal()); 
                }
                return oMemberManager; 
            }
        }
        
        public BaseController() 
        {
            
        }
    }
}
