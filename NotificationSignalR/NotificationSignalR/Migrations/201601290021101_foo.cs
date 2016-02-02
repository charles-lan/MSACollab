namespace NotificationSignalR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        ConnectionID = c.String(nullable: false, maxLength: 128),
                        UserAgent = c.String(),
                        Connected = c.Boolean(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ConnectionID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotiID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        desc = c.String(),
                    })
                .PrimaryKey(t => t.NotiID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Notification_NotiID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Notifications", t => t.Notification_NotiID)
                .Index(t => t.Notification_NotiID);
            
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UsrNID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        NotiID = c.Int(nullable: false),
                        Isread = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsrNID)
                .ForeignKey("dbo.Notifications", t => t.NotiID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.NotiID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserNotifications", "NotiID", "dbo.Notifications");
            DropForeignKey("dbo.Users", "Notification_NotiID", "dbo.Notifications");
            DropForeignKey("dbo.Connections", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserNotifications", new[] { "NotiID" });
            DropIndex("dbo.UserNotifications", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Notification_NotiID" });
            DropIndex("dbo.Connections", new[] { "User_UserID" });
            DropTable("dbo.UserNotifications");
            DropTable("dbo.Users");
            DropTable("dbo.Notifications");
            DropTable("dbo.Connections");
        }
    }
}
