
namespace GOLDEPUS.Dal.User
{
    public class Facede
    {
        private Account account;
        public Facede(DBEngine.UnitOfWorks DataProcess)
        {
            account = new Account(DataProcess);
        }

        public Entity.User.Account Login(string username,string password)
        {
            return this.account.Login(username, password);
        }

        public Base.RegisterResult Register(string userName, string password, string eMail, string name = "")
        {
            return this.account.Register(userName, password, eMail, name);
        }


    }
}
