namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemainedEntryCountrenamedtoRemainingEntries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientTicket", "RemainingEntries", c => c.Int(nullable: false));
            DropColumn("dbo.ClientTicket", "RemainedEntryCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientTicket", "RemainedEntryCount", c => c.Int(nullable: false));
            DropColumn("dbo.ClientTicket", "RemainingEntries");
        }
    }
}
