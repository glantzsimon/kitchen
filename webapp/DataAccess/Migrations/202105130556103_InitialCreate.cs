namespace K9.DataAccessLayer.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArchiveItemCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSubscriptionOnly = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.ArchiveItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublishedOn = c.DateTime(nullable: false),
                        PublishedBy = c.String(),
                        Language = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 256),
                        CategoryId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        DescriptionText = c.String(nullable: false),
                        Url = c.String(),
                        ImageUrl = c.String(maxLength: 512),
                        IsHideMetaData = c.Boolean(nullable: false),
                        IsShowLocalOnly = c.Boolean(nullable: false),
                        AdditionalCssClasses = c.String(),
                        SeoFriendlyId = c.String(),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArchiveItemCategory", t => t.CategoryId)
                .ForeignKey("dbo.ArchiveItemType", t => t.TypeId)
                .Index(t => t.CategoryId)
                .Index(t => t.TypeId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.ArchiveItemType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TwoLetterCountryCode = c.String(maxLength: 2),
                        ThreeLetterCountryCode = c.String(maxLength: 3),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TwoLetterCountryCode, unique: true)
                .Index(t => t.ThreeLetterCountryCode, unique: true)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SentByUserId = c.Int(nullable: false),
                        SentToUserId = c.Int(nullable: false),
                        SentOn = c.DateTime(nullable: false),
                        MessageDirection = c.Int(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 256),
                        Body = c.String(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.SentByUserId)
                .ForeignKey("dbo.User", t => t.SentToUserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SentByUserId)
                .Index(t => t.SentToUserId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 128),
                        Username = c.String(nullable: false, maxLength: 56),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.String(maxLength: 255),
                        BirthDate = c.DateTime(nullable: false),
                        IsUnsubscribed = c.Boolean(nullable: false),
                        IsOAuth = c.Boolean(nullable: false),
                        Gender = c.Int(nullable: true),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.NewsItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublishedOn = c.DateTime(nullable: false),
                        PublishedBy = c.String(),
                        Language = c.Int(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 256),
                        Body = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Url = c.String(maxLength: 512),
                        ImageUrl = c.String(maxLength: 512),
                        IsShowLocalOnly = c.Boolean(nullable: false),
                        AdditionalCssClasses = c.String(),
                        SeoFriendlyId = c.String(),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.RolePermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permission", t => t.PermissionId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.PermissionId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RolePermission", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RolePermission", "PermissionId", "dbo.Permission");
            DropForeignKey("dbo.Message", "UserId", "dbo.User");
            DropForeignKey("dbo.Message", "SentToUserId", "dbo.User");
            DropForeignKey("dbo.Message", "SentByUserId", "dbo.User");
            DropForeignKey("dbo.ArchiveItem", "TypeId", "dbo.ArchiveItemType");
            DropForeignKey("dbo.ArchiveItem", "CategoryId", "dbo.ArchiveItemCategory");
            DropIndex("dbo.UserRole", new[] { "Name" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", new[] { "Name" });
            DropIndex("dbo.RolePermission", new[] { "Name" });
            DropIndex("dbo.RolePermission", new[] { "PermissionId" });
            DropIndex("dbo.RolePermission", new[] { "RoleId" });
            DropIndex("dbo.Permission", new[] { "Name" });
            DropIndex("dbo.NewsItem", new[] { "Name" });
            DropIndex("dbo.User", new[] { "Name" });
            DropIndex("dbo.Message", new[] { "Name" });
            DropIndex("dbo.Message", new[] { "SentToUserId" });
            DropIndex("dbo.Message", new[] { "SentByUserId" });
            DropIndex("dbo.Message", new[] { "UserId" });
            DropIndex("dbo.Country", new[] { "Name" });
            DropIndex("dbo.Country", new[] { "ThreeLetterCountryCode" });
            DropIndex("dbo.Country", new[] { "TwoLetterCountryCode" });
            DropIndex("dbo.ArchiveItemType", new[] { "Name" });
            DropIndex("dbo.ArchiveItem", new[] { "Name" });
            DropIndex("dbo.ArchiveItem", new[] { "TypeId" });
            DropIndex("dbo.ArchiveItem", new[] { "CategoryId" });
            DropIndex("dbo.ArchiveItemCategory", new[] { "Name" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.RolePermission");
            DropTable("dbo.Permission");
            DropTable("dbo.NewsItem");
            DropTable("dbo.User");
            DropTable("dbo.Message");
            DropTable("dbo.Country");
            DropTable("dbo.ArchiveItemType");
            DropTable("dbo.ArchiveItem");
            DropTable("dbo.ArchiveItemCategory");
        }
    }
}
