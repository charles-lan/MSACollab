namespace NotificationSignalR.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NotificationSignalR.Models.NotificationSignalRContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(NotificationSignalR.Models.NotificationSignalRContext context)
        //{

        //    context.Notifications.AddOrUpdate(
        //      p => p.ID,
        //      new Notification { title = "Testing",desc="A new item has been added",date=DateTime.Now, groups = new Group[] {
        //      }
        //      },
        //      new Notification { title = "Testing", desc = "An item has been deleted", date = DateTime.Now, groups =["Shop", "North"] },
        //      new Notification { title = "Testing", desc = "An item has been updated.", date = DateTime.Now, groups =["Police", "North"] }
        //    );

        //}
    }
}
