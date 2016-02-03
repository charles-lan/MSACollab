using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotificationSignalR.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public ICollection<Connection> Connections { get; set; }

        public ICollection<UserNotification> UserNotifications { get; set; }
    }
}