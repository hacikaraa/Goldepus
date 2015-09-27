using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.User
{
    internal class Account : Base.Base<Entity.User.Account>
    {
        public Account(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }

        public Entity.User.Account Login(string username, string password)
        {
            try
            {
                var user = Reponsitory.Select(w => (w.AccountName == username || w.Email == username) && w.AccountPasword == password);
                if (user != null && user.Count() > 0)
                    return user.FirstOrDefault();
                return null;
            }
            catch (Exception ex)
            {
                base.CreateExceptionLog(ex);
                return null;
            }
        }

        public Base.RegisterResult Register(string userName, string password, string eMail, string name)
        {
            try
            {
                var user = Reponsitory.Select(w => w.AccountName == userName).FirstOrDefault();
                if (user != null) return Base.RegisterResult.UserNameAlreadyExist;
                user = Reponsitory.Select(w => w.Email == eMail).FirstOrDefault();
                if (user != null) return Base.RegisterResult.EMailAlreadyExist;

                Entity.User.Account _account = new Entity.User.Account();
                _account.AccountName = userName;
                _account.AccountPasword = password;
                _account.Email = eMail;
                _account.Name = name;
                base.Reponsitory.Insert(ref _account);
                if (base.DataProcess.Save())
                    return Base.RegisterResult.Successful;
                else
                    return Base.RegisterResult.UnknowError;
            }
            catch (Exception ex)
            {
                base.CreateExceptionLog(ex);
                return Base.RegisterResult.UnknowError;
            }
        }

    }
}
