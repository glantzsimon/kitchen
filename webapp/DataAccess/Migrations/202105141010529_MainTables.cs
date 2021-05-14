namespace K9.DataAccessLayer.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allergen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.FullName, unique: true)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.DishAllergen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DishId = c.Int(nullable: false),
                        AllergenId = c.Int(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Allergen", t => t.AllergenId)
                .ForeignKey("dbo.Dish", t => t.DishId)
                .Index(t => t.DishId)
                .Index(t => t.AllergenId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Dish",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 128),
                        DishType = c.Int(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.FullName, unique: true)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.DishSuitability",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DishId = c.Int(nullable: false),
                        SuitabilityId = c.Int(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dish", t => t.DishId)
                .ForeignKey("dbo.Suitability", t => t.SuitabilityId)
                .Index(t => t.DishId)
                .Index(t => t.SuitabilityId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Suitability",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 128),
                        IsSystemStandard = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 255),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.FullName, unique: true)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DishSuitability", "SuitabilityId", "dbo.Suitability");
            DropForeignKey("dbo.DishSuitability", "DishId", "dbo.Dish");
            DropForeignKey("dbo.DishAllergen", "DishId", "dbo.Dish");
            DropForeignKey("dbo.DishAllergen", "AllergenId", "dbo.Allergen");
            DropIndex("dbo.Suitability", new[] { "Name" });
            DropIndex("dbo.Suitability", new[] { "FullName" });
            DropIndex("dbo.DishSuitability", new[] { "Name" });
            DropIndex("dbo.DishSuitability", new[] { "SuitabilityId" });
            DropIndex("dbo.DishSuitability", new[] { "DishId" });
            DropIndex("dbo.Dish", new[] { "Name" });
            DropIndex("dbo.Dish", new[] { "FullName" });
            DropIndex("dbo.DishAllergen", new[] { "Name" });
            DropIndex("dbo.DishAllergen", new[] { "AllergenId" });
            DropIndex("dbo.DishAllergen", new[] { "DishId" });
            DropIndex("dbo.Allergen", new[] { "Name" });
            DropIndex("dbo.Allergen", new[] { "FullName" });
            DropTable("dbo.Suitability");
            DropTable("dbo.DishSuitability");
            DropTable("dbo.Dish");
            DropTable("dbo.DishAllergen");
            DropTable("dbo.Allergen");
        }
    }
}
