namespace LibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Copies", "Reader", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Copies", "Reader", c => c.Int(nullable: false));
        }
    }
}
