using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aybala.Tool.Cryptology;

namespace GOLDEPUS.Bll.User
{
    public class Facede
    {
        private Account account;
        public Facede(Bll.Facede Application)
        {
            account = new Account(Application);
        }
        
        public ResultObject<Entity.User.Account> Login(string username,string password)
        {
            return this.account.Login(username, MD5.MD5Create(password));
        }

        public ResultObject<Entity.User.Account> Register(string userName, string password, string eMail, string name)
        {
            return this.account.Register(userName, MD5.MD5Create(password), eMail, name);
        }

        public void LogOut()
        {
            this.account.LogOut();
        }

    }
}
