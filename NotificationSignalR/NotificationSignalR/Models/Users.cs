using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationSignalR.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public int LastReadID { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}