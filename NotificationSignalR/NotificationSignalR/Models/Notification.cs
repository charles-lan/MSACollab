using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotificationSignalR.Models
{
    public class Notification
    {
        [Key]
        public int NotiID { get; set; }
        public string title { get; set; }
        public string desc { get; set; }

        public ICollection<UserNotification> Recipients { get; set; }
    }
}