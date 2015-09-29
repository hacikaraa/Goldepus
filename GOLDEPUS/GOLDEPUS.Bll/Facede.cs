using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll
{
    public class Facede
    {
        public Facede() { }

        public Facede(Entity.DBEngine.UnitOfWorks dataProcess) { this.dataProcess = dataProcess; }

        private Entity.DBEngine.DataContext dbContext;
        internal Entity.DBEngine.DataContext DBContext
        {
            get
            {
                if (this.dbContext == null)
                {
                    this.dbContext = new Entity.DBEngine.DataContext();
                    this.dbContext.Database.CreateIfNotExists();
                }
                return this.dbContext;
            }
        }

        private Entity.DBEngine.UnitOfWorks dataProcess;
        internal Entity.DBEngine.UnitOfWorks DataProcess
        {
            get
            {
                if (this.dataProcess == null) this.dataProcess = new Entity.DBEngine.UnitOfWorks(this.DBContext);
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
                if (marketing == null) marketing = new Marketing.Facede(this.DataProcess);
                return marketing;
            }
        }

        private Monitoring.Facede monitoring;
        public Monitoring.Facede Monitoring
        {
            get
            {
                if (monitoring == null) monitoring = new Monitoring.Facede(this.DataProcess);
                return monitoring;
            }
        }

        private User.Facede user;
        public User.Facede User
        {
            get
            {
                if (user == null) user = new User.Facede(this.DataProcess);
                return user;
            }
        }
    }
}