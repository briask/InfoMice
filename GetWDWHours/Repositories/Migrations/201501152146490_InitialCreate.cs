namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkOperatingHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParkDate = c.DateTime(nullable: false),
                        ParkActive = c.Boolean(nullable: false),
                        HasExtraHours = c.Boolean(nullable: false),
                        ParkClosed = c.DateTime(),
                        ParkReopen = c.DateTime(),
                        NormalOpen = c.DateTime(),
                        NormalClose = c.DateTime(),
                        EarlyOpen = c.DateTime(),
                        EarlyClose = c.DateTime(),
                        LateOpen = c.DateTime(),
                        LateClose = c.DateTime(),
                        Updated = c.DateTime(nullable: false),
                        ParkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parks", t => t.ParkId, cascadeDelete: true)
                .Index(t => t.ParkId);
            
            CreateTable(
                "dbo.Parks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkOperatingHours", "ParkId", "dbo.Parks");
            DropIndex("dbo.ParkOperatingHours", new[] { "ParkId" });
            DropTable("dbo.Parks");
            DropTable("dbo.ParkOperatingHours");
        }
    }
}
