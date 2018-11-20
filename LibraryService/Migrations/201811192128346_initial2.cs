namespace LibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.copies", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
