
namespace GOLDEPUS.Dal
{
    public class Facede
    {
        public Facede() { }

        public Facede(DBEngine.UnitOfWorks dataProcess) { this.dataProcess = dataProcess; }

        private DBEngine.DataContext dbContext;
        internal DBEngine.DataContext DBContext
        {
            get
            {
                if (this.dbContext == null)
                {
                    this.dbContext = new DBEngine.DataContext();
                    this.dbContext.Database.CreateIfNotExists();
                }
                return this.dbContext;
            }
        }

        private DBEngine.UnitOfWorks dataProcess;
        internal DBEngine.UnitOfWorks DataProcess
        {
            get
            {
                if (this.dataProcess == null) this.dataProcess = new DBEngine.UnitOfWorks(this.DBContext);
                return this.dataProcess;
            }
        }

        private Catalog.Facede catalog;
        public Catalog.Facede Catalog
        {
            get
            {
                if (catalog == null) catalog = new Catalog.Facede(this.DataProcess);
                return catalog;
            }
        }

        private Content.Facede content;
        public Content.Facede Content
        {
            get
            {
                if (content == null) content = new Content.Facede(this.DataProcess);
                return content;
            }
        }

        private Finance.Facede finance;
        public Finance.Facede Finance
        {
            get
            {
                if (finance == null) finance = new Finance.Facede(this.DataProcess);
                return finance;
            }
        }

        private Formal.Facede formal;
        public Formal.Facede Formal
        {
            get
            {
                if (formal == null) formal = new Formal.Facede(this.DataProcess);
                return formal;
            }
        }

        private Framework.Facede framework;
        public Framework.Facede Framework
        {
            get
            {
                if (framework == null) framework = new Framework.Facede(this.DataProcess);
                return framework;
            }
        }

        private Marketing.Facede marketing;
        public Marketing.Facede Marketing
        {
            get
            {
                if (marketing == null) marketing = new Dal.Marketing.Facede(this.DataProcess);
                return marketing;
            }
        }

        private Monitoring.Facede monitoring;
        public Monitoring.Facede Monitoring
        {
            get
            {
                if (monitoring == null) monitoring = new Dal.Monitoring.Facede(this.DataProcess);
                return monitoring;
            }
        }

        private User.Facede user;
        public User.Facede User
        {
            get
            {
                if (user == null) user = new Dal.User.Facede(this.DataProcess);
                return user;
            }
        }




    }
}
