namespace LibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                {
                    Isbn = c.String(nullable: false, maxLength: 128),
                    Title = c.String(nullable: false),
                    Author = c.String(nullable: false),
                    Date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Isbn);

            AlterColumn("dbo.Copies", "Isbn", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Copies", "Reader");
            CreateIndex("dbo.Copies", "Isbn");
            AddForeignKey("dbo.Copies", "Isbn", "dbo.Books", "Isbn", cascadeDelete: true);
            AddForeignKey("dbo.Copies", "Reader", "dbo.Readers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Copies", "Reader", "dbo.Readers");
            DropForeignKey("dbo.Copies", "Isbn", "dbo.Books");
            DropIndex("dbo.Copies", new[] { "Isbn" });
            DropIndex("dbo.Copies", new[] { "Reader" });
            AlterColumn("dbo.Copies", "Isbn", c => c.String(nullable: false));
        }
    }
}
