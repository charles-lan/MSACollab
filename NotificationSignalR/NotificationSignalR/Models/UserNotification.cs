using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace NotificationSignalR.Models
{
    public class UserNotification
    {
        [Key]
        public int UsrNID { get; set; }
        public int UserId { get; set; }
        public int NotiID { get; set; }
        public bool Isread { get; set; }

        [JsonIgnore]
        public virtual Notification Notification { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}