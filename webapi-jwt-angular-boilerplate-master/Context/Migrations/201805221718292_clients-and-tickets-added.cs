namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientsandticketsadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "MovieTypeId", "dbo.MovieType");
            DropIndex("dbo.Movie", new[] { "MovieTypeId" });
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientTicket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        RemainedEntryCount = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Ticket", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        EntryCount = c.Int(nullable: false),
                        ValidityDayCount = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Movie");
            DropTable("dbo.MovieType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        MovieTypeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        OwnerId = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.ClientTicket", "TicketId", "dbo.Ticket");
            DropForeignKey("dbo.ClientTicket", "ClientId", "dbo.Client");
            DropIndex("dbo.ClientTicket", new[] { "TicketId" });
            DropIndex("dbo.ClientTicket", new[] { "ClientId" });
            DropTable("dbo.Ticket");
            DropTable("dbo.ClientTicket");
            DropTable("dbo.Client");
            CreateIndex("dbo.Movie", "MovieTypeId");
            AddForeignKey("dbo.Movie", "MovieTypeId", "dbo.MovieType", "Id", cascadeDelete: true);
        }
    }
}
