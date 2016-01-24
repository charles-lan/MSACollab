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
        public string Title { get; set; }
        public string Desc { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}