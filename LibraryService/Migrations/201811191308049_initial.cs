namespace LibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Readers");
            DropTable("dbo.Copies");
            DropTable("dbo.Books");
        }
    }
}
