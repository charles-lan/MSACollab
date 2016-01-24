using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationSignalR.Models
{
    public class Group
    {
        public int groupID { get; set; }
        public string groupName { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}