using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll
{
    public class Facede
    {


        private Catalog.Facede catalog;
        public Catalog.Facede Catalog
        {
            get
            {
                if (catalog == null) catalog = new Catalog.Facede();
                return catalog;
            }
        }

        private Content.Facede content;
        public Content.Facede Content
        {
            get
            {
                if (content == null) content = new Content.Facede();
                return content;
            }
        }

        private Finance.Facede finance;
        public Finance.Facede Finance
        {
            get
            {
                if (finance == null) finance = new Finance.Facede();
                return finance;
            }
        }

        private Formal.Facede formal;
        public Formal.Facede Formal
        {
            get
            {
                if (formal == null) formal = new Formal.Facede();
                return formal;
            }
        }

        private Framework.Facede framework;
        public Framework.Facede Framework
        {
            get
            {
                if (framework == null) framework = new Framework.Facede();
                return framework;
            }
        }

        private Marketing.Facede marketing;
        public Marketing.Facede Marketing
        {
            get
            {
                if (marketing == null) marketing = new Marketing.Facede();
                return marketing;
            }
        }

        private Monitoring.Facede monitoring;
        public Monitoring.Facede Monitoring
        {
            get
            {
                if (monitoring == null) monitoring = new Monitoring.Facede();
                return monitoring;
            }
        }

        private User.Facede user;
        public User.Facede User
        {
            get
            {
                if (user == null) user = new User.Facede();
                return user;
            }
        }
    }
}