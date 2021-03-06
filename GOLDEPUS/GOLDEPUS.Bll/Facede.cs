﻿using GOLDEPUS.Entity.DBEngine;
using GOLDEPUS.Entity.Migrations;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace GOLDEPUS.Bll
{
    public class Facede
    {
        public Facede()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
        }

        private Entity.DBEngine.DataContext dbContext;
        internal Entity.DBEngine.DataContext DBContext
        {
            get
            {
                if (this.dbContext == null)
                {
                    this.dbContext = new DataContext();
                    var dbMigrator = new DbMigrator(new Configuration());
                    dbMigrator.Update();
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
                if (catalog == null) catalog = new Catalog.Facede(this);
                return catalog;
            }
        }

        private Content.Facede content;
        public Content.Facede Content
        {
            get
            {
                if (content == null) content = new Content.Facede(this);
                return content;
            }
        }

        private Finance.Facede finance;
        public Finance.Facede Finance
        {
            get
            {
                if (finance == null) finance = new Finance.Facede(this);
                return finance;
            }
        }

        private Formal.Facede formal;
        public Formal.Facede Formal
        {
            get
            {
                if (formal == null) formal = new Formal.Facede(this);
                return formal;
            }
        }

        private Framework.Facede framework;
        public Framework.Facede Framework
        {
            get
            {
                if (framework == null) framework = new Framework.Facede(this);
                return framework;
            }
        }

        private Marketing.Facede marketing;
        public Marketing.Facede Marketing
        {
            get
            {
                if (marketing == null) marketing = new Marketing.Facede(this);
                return marketing;
            }
        }

        private Monitoring.Facede monitoring;
        public Monitoring.Facede Monitoring
        {
            get
            {
                if (monitoring == null) monitoring = new Monitoring.Facede(this);
                return monitoring;
            }
        }

        private User.Facede user;
        public User.Facede User
        {
            get
            {
                if (user == null) user = new User.Facede(this);
                return user;
            }
        }
    }
}