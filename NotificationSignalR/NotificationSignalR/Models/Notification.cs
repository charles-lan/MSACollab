using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotificationSignalR.Models
{
    public class Notification
    {
        
        public int ID { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public virtual ICollection<Group> groups { get; set; }
    }
}