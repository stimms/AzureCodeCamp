namespace PancakeProwler.Data.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Contributor = c.String(),
                        Ingredients = c.String(),
                        Steps = c.String(),
                        ImageLocation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        SponsorName = c.String(),
                        SponsorWebSite = c.String(),
                        SponsorEMail = c.String(),
                        SponsorTwitter = c.String(),
                        ContactName = c.String(nullable: false),
                        ContactEMail = c.String(),
                        ContactPhoneNumber = c.String(),
                        Address = c.String(),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        ImageLocation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Meals");
            DropTable("dbo.Recipes");
        }
    }
}
