namespace LibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Copies", "Reader", c => c.Int(nullable: false));
            AlterColumn("dbo.Copies", "Borrowed", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Copies", "Borrowed", c => c.DateTime());
            AlterColumn("dbo.Copies", "Reader", c => c.Int());
        }
    }
}
