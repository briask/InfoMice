namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idx_parkDate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("ParkOperatingHours", "ParkDate", false, "idx_parkDate");
        }
        
        public override void Down()
        {
            DropIndex("ParkOperatingHours", "idx_parkDate");
        }
    }
}
