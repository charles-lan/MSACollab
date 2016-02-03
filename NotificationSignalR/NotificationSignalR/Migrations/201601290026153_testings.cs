namespace NotificationSignalR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Notification_NotiID", "dbo.Notifications");
            DropIndex("dbo.Users", new[] { "Notification_NotiID" });
            CreateTable(
                "dbo.UserNotification1",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Notification_NotiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Notification_NotiID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Notifications", t => t.Notification_NotiID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Notification_NotiID);
            
            DropColumn("dbo.Users", "Notification_NotiID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Notification_NotiID", c => c.Int());
            DropForeignKey("dbo.UserNotification1", "Notification_NotiID", "dbo.Notifications");
            DropForeignKey("dbo.UserNotification1", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserNotification1", new[] { "Notification_NotiID" });
            DropIndex("dbo.UserNotification1", new[] { "User_UserID" });
            DropTable("dbo.UserNotification1");
            CreateIndex("dbo.Users", "Notification_NotiID");
            AddForeignKey("dbo.Users", "Notification_NotiID", "dbo.Notifications", "NotiID");
        }
    }
}
