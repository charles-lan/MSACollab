namespace NotificationSignalR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserNotification1", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserNotification1", "Notification_NotiID", "dbo.Notifications");
            DropIndex("dbo.UserNotification1", new[] { "User_UserID" });
            DropIndex("dbo.UserNotification1", new[] { "Notification_NotiID" });
            DropTable("dbo.UserNotification1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserNotification1",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Notification_NotiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Notification_NotiID });
            
            CreateIndex("dbo.UserNotification1", "Notification_NotiID");
            CreateIndex("dbo.UserNotification1", "User_UserID");
            AddForeignKey("dbo.UserNotification1", "Notification_NotiID", "dbo.Notifications", "NotiID", cascadeDelete: true);
            AddForeignKey("dbo.UserNotification1", "User_UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
