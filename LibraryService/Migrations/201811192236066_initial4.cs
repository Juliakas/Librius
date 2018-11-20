namespace LibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Copies", "Borrowed", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Copies", "Borrowed", c => c.DateTime(nullable: false));
        }
    }
}
