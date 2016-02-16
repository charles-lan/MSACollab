using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationHubAPI.Models
{
    public class Notification
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
    }
}