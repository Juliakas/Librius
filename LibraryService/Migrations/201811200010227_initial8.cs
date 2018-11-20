namespace LibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Copies");
            AlterColumn("dbo.Copies", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Copies", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Copies");
            AlterColumn("dbo.Copies", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Copies", "Id");
        }
    }
}
