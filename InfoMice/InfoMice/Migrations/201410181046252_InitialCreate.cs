namespace InfoMice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acronyms",
                c => new
                    {
                        AcronymId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FullName = c.String(),
                        Meaning = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.AcronymId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Acronyms");
        }
    }
}
