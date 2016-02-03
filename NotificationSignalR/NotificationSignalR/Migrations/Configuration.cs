namespace NotificationSignalR.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<NotificationSignalR.Models.NotificationSignalRContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NotificationSignalR.Models.NotificationSignalRContext context)
        {

            var _users = new List<User>
            {
                new User { UserName = "NorthShop", UserNotifications = new List<UserNotification>()},
                new User { UserName = "NorthPolice", UserNotifications = new List<UserNotification>() },
                new User { UserName = "SouthShop", UserNotifications = new List<UserNotification>()},
                new User { UserName = "JustAUser", UserNotifications = new List<UserNotification>()}
            };

            _users.ForEach(s => context.Users.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();




            var _noti = new List<Notification>
            {
                new Notification { title = "A notification for Police",desc="For Police", Recipients = new List<UserNotification>()},
                new Notification { title = "A notification for Shops",desc="For Shops", Recipients = new List<UserNotification>()},
                new Notification { title = "A notification for North",desc="For North", Recipients = new List<UserNotification>()},
            };


            _noti.ForEach(s => context.Notifications.AddOrUpdate(p => p.desc, s));
            context.SaveChanges();

            var _usernotifications = new List<UserNotification>
            {
                new UserNotification { NotiID = _noti.Single( s => s.desc == "For Police").NotiID,
                                       UserId = _users.Single(s => s.UserName == "NorthPolice").UserID,
                                       Isread = false },
                new UserNotification { NotiID = _noti.Single( s => s.desc == "For Shops").NotiID,
                                       UserId = _users.Single(s => s.UserName == "NorthShop").UserID,
                                       Isread = false },
                new UserNotification { NotiID = _noti.Single( s => s.desc == "For Shops").NotiID,
                                       UserId = _users.Single(s => s.UserName == "SouthShop").UserID,
                                       Isread = false },
                new UserNotification { NotiID = _noti.Single( s => s.desc == "For North").NotiID,
                                       UserId = _users.Single(s => s.UserName == "NorthPolice").UserID,
                                       Isread = false },
                new UserNotification { NotiID = _noti.Single( s => s.desc == "For North").NotiID,
                                       UserId = _users.Single(s => s.UserName == "NorthShop").UserID,
                                       Isread = false },
            };

            foreach(UserNotification u in _usernotifications)
            {
                var usernotifInDataBase = context.UserNotifications.Where(
                    s =>
                        s.User.UserID == u.UserId &&
                        s.Notification.NotiID == u.NotiID).SingleOrDefault();
                
                if (usernotifInDataBase == null)
                {
                    context.UserNotifications.Add(u);
                }

                context.SaveChanges();
            }


        }

    }
}
