using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Models
{
    public class BaseModel : GOLDEPUS.MVC.Models.BaseModel
    {
        private GOLDEPUS.Entity.User.Account activeUser = (GOLDEPUS.Entity.User.Account)HttpContext.Current.Session["User"];
        public GOLDEPUS.Entity.User.Account ActiveUser
        {
            get
            {
                if (String.IsNullOrEmpty(this.activeUser.ImagePath))
                    this.activeUser.ImagePath = "/Content/images/account-manager.jpg";
                return activeUser;
            }
        }
    }
}