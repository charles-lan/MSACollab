namespace NotificationSignalR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foobar1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "date");
        }
    }
}
