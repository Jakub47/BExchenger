namespace Wymieniator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 75),
                        Publisher = c.String(nullable: false, maxLength: 75),
                        FirstNameOfAuthor = c.String(nullable: false, maxLength: 75),
                        LastNameOfAuthor = c.String(nullable: false, maxLength: 100),
                        PublicationDate = c.DateTime(nullable: false),
                        Pages = c.Int(nullable: false),
                        Language = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        ShortDescription = c.String(nullable: false, maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                        BooksForExchange = c.String(),
                        DateOfInsert = c.DateTime(nullable: false),
                        Edition = c.Int(nullable: false),
                        HardCover = c.Boolean(nullable: false),
                        MainPicture = c.String(),
                        Exchange_ExchangeId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Exchange", t => t.Exchange_ExchangeId)
                .Index(t => t.CategoryId)
                .Index(t => t.Exchange_ExchangeId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        Picture = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Exchange",
                c => new
                    {
                        ExchangeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 75),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Street = c.String(nullable: false, maxLength: 100),
                        Town = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.String(nullable: false),
                        TelephoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Info = c.String(maxLength: 50),
                        DateOfInsert = c.DateTime(nullable: false),
                        Accepted = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExchangeId);
            
            CreateTable(
                "dbo.PositionOfExchange",
                c => new
                    {
                        PositionOfExchangeId = c.Int(nullable: false, identity: true),
                        ExchangeId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PositionOfExchangeId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Exchange", t => t.ExchangeId, cascadeDelete: true)
                .Index(t => t.ExchangeId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PositionOfExchange", "ExchangeId", "dbo.Exchange");
            DropForeignKey("dbo.PositionOfExchange", "BookId", "dbo.Book");
            DropForeignKey("dbo.Book", "Exchange_ExchangeId", "dbo.Exchange");
            DropForeignKey("dbo.Photo", "BookId", "dbo.Book");
            DropForeignKey("dbo.Book", "CategoryId", "dbo.Category");
            DropIndex("dbo.PositionOfExchange", new[] { "BookId" });
            DropIndex("dbo.PositionOfExchange", new[] { "ExchangeId" });
            DropIndex("dbo.Photo", new[] { "BookId" });
            DropIndex("dbo.Book", new[] { "Exchange_ExchangeId" });
            DropIndex("dbo.Book", new[] { "CategoryId" });
            DropTable("dbo.PositionOfExchange");
            DropTable("dbo.Exchange");
            DropTable("dbo.Photo");
            DropTable("dbo.Category");
            DropTable("dbo.Book");
        }
    }
}
