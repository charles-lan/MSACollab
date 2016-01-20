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

        protected override void Seed(NotificationSignalR.Models.NotificationSignalRContext context)
        {

            context.Notifications.AddOrUpdate(
              p => p.ID,
              new Notification { title = "Testing",desc="A new item has been added" },
              new Notification { title = "Testing", desc = "An item has been deleted" },
              new Notification { title = "Testing", desc = "An item has been updated." }
            );

        }
    }
}
