namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idx_updated : DbMigration
    {
        public override void Up()
        {
            CreateIndex("ParkOperatingHours", "Updated",false, "idx_updated");
        }
        
        public override void Down()
        {
            DropIndex("ParkOperatingHours", "idx_updated");
        }
    }
}
