namespace LibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DTO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Readers", "Email", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.Readers", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Readers", new[] { "Email" });
            DropColumn("dbo.Readers", "Email");
        }
    }
}
