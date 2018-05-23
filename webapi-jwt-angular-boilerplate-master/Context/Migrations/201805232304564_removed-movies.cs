namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedmovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "MovieTypeId", "dbo.MovieType");
            DropIndex("dbo.Movie", new[] { "MovieTypeId" });
            DropTable("dbo.MovieType");
            DropTable("dbo.Movie");
        }
        
        public override void Down()
        {
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
            
            CreateTable(
                "dbo.MovieType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Movie", "MovieTypeId");
            AddForeignKey("dbo.Movie", "MovieTypeId", "dbo.MovieType", "Id", cascadeDelete: true);
        }
    }
}
