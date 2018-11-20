namespace LibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Copies",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Reader = c.Int(nullable: true),
                    Isbn = c.String(nullable: false),
                    Borrowed = c.DateTime(nullable: true),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
        }
    }
}
