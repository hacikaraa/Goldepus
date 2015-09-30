namespace GOLDEPUS.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountName = c.String(maxLength: 32),
                        AccountPasword = c.String(maxLength: 32, fixedLength: true, unicode: false),
                        Email = c.String(maxLength: 32),
                        ImagePath = c.String(),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Corporation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.CorporationExpenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Corporation_Id = c.Int(),
                        Expenses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Corporation", t => t.Corporation_Id)
                .ForeignKey("dbo.Expenses", t => t.Expenses_Id)
                .Index(t => t.Corporation_Id)
                .Index(t => t.Expenses_Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpenseItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Expenses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expenses", t => t.Expenses_Id)
                .Index(t => t.Expenses_Id);
            
            CreateTable(
                "dbo.CorporationMember",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Account_Id = c.Int(),
                        Corporation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .ForeignKey("dbo.Corporation", t => t.Corporation_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Corporation_Id);
            
            CreateTable(
                "dbo.CorporationRevenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Corporation_Id = c.Int(),
                        Revenues_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Corporation", t => t.Corporation_Id)
                .ForeignKey("dbo.Revenues", t => t.Revenues_Id)
                .Index(t => t.Corporation_Id)
                .Index(t => t.Revenues_Id);
            
            CreateTable(
                "dbo.Revenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RevenueItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Revenues_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Revenues", t => t.Revenues_Id)
                .Index(t => t.Revenues_Id);
            
            CreateTable(
                "dbo.CorporationList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Corporation_Id = c.Int(),
                        List_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Corporation", t => t.Corporation_Id)
                .ForeignKey("dbo.List", t => t.List_Id)
                .Index(t => t.Corporation_Id)
                .Index(t => t.List_Id);
            
            CreateTable(
                "dbo.List",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ListItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        List_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.List", t => t.List_Id)
                .Index(t => t.List_Id);
            
            CreateTable(
                "dbo.Column",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ListColumn_Id = c.Int(),
                        ListItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ListColumns", t => t.ListColumn_Id)
                .ForeignKey("dbo.ListItem", t => t.ListItem_Id)
                .Index(t => t.ListColumn_Id)
                .Index(t => t.ListItem_Id);
            
            CreateTable(
                "dbo.ListColumns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Label_Id = c.Int(),
                        List_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Label", t => t.Label_Id)
                .ForeignKey("dbo.List", t => t.List_Id)
                .Index(t => t.Label_Id)
                .Index(t => t.List_Id);
            
            CreateTable(
                "dbo.Label",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        BaseCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.BaseCategory_Id)
                .Index(t => t.BaseCategory_Id);
            
            CreateTable(
                "dbo.MemberExpenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Account_Id = c.Int(),
                        Expenses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .ForeignKey("dbo.Expenses", t => t.Expenses_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Expenses_Id);
            
            CreateTable(
                "dbo.MemberList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Account_Id = c.Int(),
                        List_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .ForeignKey("dbo.List", t => t.List_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.List_Id);
            
            CreateTable(
                "dbo.MemberRevenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Account_Id = c.Int(),
                        Revenues_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .ForeignKey("dbo.Revenues", t => t.Revenues_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Revenues_Id);
            
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExceptionLog",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ExceptionMessage = c.String(),
                        ExceptionCode = c.String(),
                        Exception = c.String(),
                        AccountId = c.Int(nullable: false),
                        ExecuteEntity = c.String(),
                        ExecuteType = c.String(),
                        EntityValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExecuteLog",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                        ExecuteEntity = c.String(),
                        ExecuteType = c.String(),
                        EntityValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCampaign",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Campaign_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_Id)
                .ForeignKey("dbo.Item", t => t.Item_Id)
                .Index(t => t.Campaign_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Group_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .ForeignKey("dbo.Item", t => t.Item_Id)
                .Index(t => t.Group_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ImageBase64 = c.String(),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserCreated = c.Int(),
                        UserModified = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Item_Id = c.Int(),
                        Label_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.Item_Id)
                .ForeignKey("dbo.Label", t => t.Label_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Label_Id);
            
            CreateTable(
                "dbo.PerformanceLog",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StartActivity = c.DateTime(nullable: false),
                        FinishActivity = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                        ExecuteEntity = c.String(),
                        ExecuteType = c.String(),
                        EntityValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemProperties", "Label_Id", "dbo.Label");
            DropForeignKey("dbo.ItemProperties", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.ItemImages", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.ItemGroups", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.ItemGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.ItemCampaign", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.ItemCampaign", "Campaign_Id", "dbo.Campaigns");
            DropForeignKey("dbo.MemberRevenues", "Revenues_Id", "dbo.Revenues");
            DropForeignKey("dbo.MemberRevenues", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.MemberList", "List_Id", "dbo.List");
            DropForeignKey("dbo.MemberList", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.MemberExpenses", "Expenses_Id", "dbo.Expenses");
            DropForeignKey("dbo.MemberExpenses", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.Corporation", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.CorporationList", "List_Id", "dbo.List");
            DropForeignKey("dbo.ListItem", "List_Id", "dbo.List");
            DropForeignKey("dbo.Column", "ListItem_Id", "dbo.ListItem");
            DropForeignKey("dbo.ListColumns", "List_Id", "dbo.List");
            DropForeignKey("dbo.ListColumns", "Label_Id", "dbo.Label");
            DropForeignKey("dbo.Label", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Category", "BaseCategory_Id", "dbo.Category");
            DropForeignKey("dbo.Column", "ListColumn_Id", "dbo.ListColumns");
            DropForeignKey("dbo.CorporationList", "Corporation_Id", "dbo.Corporation");
            DropForeignKey("dbo.CorporationRevenues", "Revenues_Id", "dbo.Revenues");
            DropForeignKey("dbo.RevenueItem", "Revenues_Id", "dbo.Revenues");
            DropForeignKey("dbo.CorporationRevenues", "Corporation_Id", "dbo.Corporation");
            DropForeignKey("dbo.CorporationMember", "Corporation_Id", "dbo.Corporation");
            DropForeignKey("dbo.CorporationMember", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.CorporationExpenses", "Expenses_Id", "dbo.Expenses");
            DropForeignKey("dbo.ExpenseItem", "Expenses_Id", "dbo.Expenses");
            DropForeignKey("dbo.CorporationExpenses", "Corporation_Id", "dbo.Corporation");
            DropIndex("dbo.ItemProperties", new[] { "Label_Id" });
            DropIndex("dbo.ItemProperties", new[] { "Item_Id" });
            DropIndex("dbo.ItemImages", new[] { "Item_Id" });
            DropIndex("dbo.ItemGroups", new[] { "Item_Id" });
            DropIndex("dbo.ItemGroups", new[] { "Group_Id" });
            DropIndex("dbo.ItemCampaign", new[] { "Item_Id" });
            DropIndex("dbo.ItemCampaign", new[] { "Campaign_Id" });
            DropIndex("dbo.MemberRevenues", new[] { "Revenues_Id" });
            DropIndex("dbo.MemberRevenues", new[] { "Account_Id" });
            DropIndex("dbo.MemberList", new[] { "List_Id" });
            DropIndex("dbo.MemberList", new[] { "Account_Id" });
            DropIndex("dbo.MemberExpenses", new[] { "Expenses_Id" });
            DropIndex("dbo.MemberExpenses", new[] { "Account_Id" });
            DropIndex("dbo.Category", new[] { "BaseCategory_Id" });
            DropIndex("dbo.Label", new[] { "Category_Id" });
            DropIndex("dbo.ListColumns", new[] { "List_Id" });
            DropIndex("dbo.ListColumns", new[] { "Label_Id" });
            DropIndex("dbo.Column", new[] { "ListItem_Id" });
            DropIndex("dbo.Column", new[] { "ListColumn_Id" });
            DropIndex("dbo.ListItem", new[] { "List_Id" });
            DropIndex("dbo.CorporationList", new[] { "List_Id" });
            DropIndex("dbo.CorporationList", new[] { "Corporation_Id" });
            DropIndex("dbo.RevenueItem", new[] { "Revenues_Id" });
            DropIndex("dbo.CorporationRevenues", new[] { "Revenues_Id" });
            DropIndex("dbo.CorporationRevenues", new[] { "Corporation_Id" });
            DropIndex("dbo.CorporationMember", new[] { "Corporation_Id" });
            DropIndex("dbo.CorporationMember", new[] { "Account_Id" });
            DropIndex("dbo.ExpenseItem", new[] { "Expenses_Id" });
            DropIndex("dbo.CorporationExpenses", new[] { "Expenses_Id" });
            DropIndex("dbo.CorporationExpenses", new[] { "Corporation_Id" });
            DropIndex("dbo.Corporation", new[] { "Account_Id" });
            DropTable("dbo.PerformanceLog");
            DropTable("dbo.ItemProperties");
            DropTable("dbo.ItemImages");
            DropTable("dbo.ItemGroups");
            DropTable("dbo.ItemCampaign");
            DropTable("dbo.Item");
            DropTable("dbo.Groups");
            DropTable("dbo.ExecuteLog");
            DropTable("dbo.ExceptionLog");
            DropTable("dbo.Campaigns");
            DropTable("dbo.MemberRevenues");
            DropTable("dbo.MemberList");
            DropTable("dbo.MemberExpenses");
            DropTable("dbo.Category");
            DropTable("dbo.Label");
            DropTable("dbo.ListColumns");
            DropTable("dbo.Column");
            DropTable("dbo.ListItem");
            DropTable("dbo.List");
            DropTable("dbo.CorporationList");
            DropTable("dbo.RevenueItem");
            DropTable("dbo.Revenues");
            DropTable("dbo.CorporationRevenues");
            DropTable("dbo.CorporationMember");
            DropTable("dbo.ExpenseItem");
            DropTable("dbo.Expenses");
            DropTable("dbo.CorporationExpenses");
            DropTable("dbo.Corporation");
            DropTable("dbo.Account");
        }
    }
}
