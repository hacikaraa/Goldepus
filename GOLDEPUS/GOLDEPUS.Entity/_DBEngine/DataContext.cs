using System.Data.Entity;

namespace GOLDEPUS.Entity.DBEngine
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
            
        }

        #region DbSets

        #region Catalog

        public DbSet<Entity.Catalog.Column> Columns { get; set; }

        public DbSet<Entity.Catalog.CorporationList> CorporationLists { get; set; }

        public DbSet<Entity.Catalog.List> List { get; set; }

        public DbSet<Entity.Catalog.ListColumns> ListColumnses { get; set; }

        public DbSet<Entity.Catalog.ListItem> ListItems { get; set; }

        public DbSet<Entity.Catalog.MemberList> MemberLists { get; set; }

        public DbSet<Entity.Catalog.Groups> Groups { get; set; }

        #endregion

        #region Content

        public DbSet<Entity.Content.Country> Countries { get; set; }

        #endregion

        #region Finance 

        public DbSet<Entity.Finance.CorporationExpenses> CorporationExpenses { get; set; }

        public DbSet<Entity.Finance.CorporationRevenues> CorporationRevenues { get; set; }

        public DbSet<Entity.Finance.ExpenseItem> ExpenseItems { get; set; }

        public DbSet<Entity.Finance.Expenses> Expenses { get; set; }

        public DbSet<Entity.Finance.MemberExpenses> MemberExpenses { get; set; }

        public DbSet<Entity.Finance.MemberRevenues> MemberRevenues { get; set; }

        public DbSet<Entity.Finance.RevenueItem> RevenueItems { get; set; }

        public DbSet<Entity.Finance.Revenues> Revenues { get; set; }

        #endregion

        #region Formal

        public DbSet<Entity.Formal.Corporation> Corporations { get; set; }

        public DbSet<Entity.Formal.CorporationMember> CorporationMembers { get; set; }

        #endregion

        #region Framework

        public DbSet<Entity.Framework.Category> Categories { get; set; }

        public DbSet<Entity.Framework.Label> Labels { get; set; }

        #endregion

        #region Marketing

        public DbSet<Entity.Marketing.Campaign> Campaigns { get; set; }

        public DbSet<Entity.Marketing.Item> Item { get; set; }

        public DbSet<Entity.Marketing.ItemCampaign> ItemCampaigns { get; set; }

        public DbSet<Entity.Marketing.ItemGroups> ItemGroups { get; set; }

        public DbSet<Entity.Marketing.ItemImages> ItemImages { get; set; }

        public DbSet<Entity.Marketing.ItemProperties> ItemProperties { get; set; }

        #endregion

        #region Monitoring

        public DbSet<Entity.Monitoring.ExceptionLog> ExceptionLogs { get; set; }

        public DbSet<Entity.Monitoring.ExecuteLog> ExecuteLogs { get; set; }

        public DbSet<Entity.Monitoring.PerformanceLog> PerformanceLogs { get; set; }

        #endregion

        #region User

        public DbSet<Entity.User.Account> Accounts { get; set; }

        #endregion

        #endregion
    }
}
