using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Models
{
    public class HomeMembersModel : BaseModel
    {
        private List<GOLDEPUS.Entity.User.Account> users;
        public List<GOLDEPUS.Entity.User.Account> Users
        {
            get
            {
                if(this.ActiveUser.Corporations != null && this.ActiveUser.Corporations.Count > 0)
                {
                    users = new List<GOLDEPUS.Entity.User.Account>();
                    foreach (var item in this.ActiveUser.Corporations.FirstOrDefault().CorporationMembers.ToList())
                    {
                        users.Add(item.Account);
                    }
                }
                return users;
            }
        }
    }
}