using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationSignalR.Models
{
    public class Notification
    {
        
        public int ID { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
    }
}