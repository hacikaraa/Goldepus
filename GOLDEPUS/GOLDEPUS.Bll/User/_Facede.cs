using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.User
{
    public class Facede
    {
        private Account account;
        public Facede(Entity.DBEngine.UnitOfWorks DataProcess)
        {
            account = new Account(DataProcess);
        }
        
        public ResultObject<Entity.User.Account> Login(string username,string password)
        {
            return this.account.Login(username, password);
        }

        public ResultObject<Entity.User.Account> Register(string userName, string password, string eMail, string name)
        {
            return this.account.Register(userName, password, eMail, name);
        }

    }
}
