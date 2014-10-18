namespace InfoMice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rev1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Acronyms", "Abreviation", c => c.String());
            DropColumn("dbo.Acronyms", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Acronyms", "Name", c => c.String());
            DropColumn("dbo.Acronyms", "Abreviation");
        }
    }
}
