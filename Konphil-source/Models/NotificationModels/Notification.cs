using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konphil.Models.NotificationModels
{
    public class Notification
    {
        public Guid Id { get; set; }
        public NotificationType Type { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
     public enum NotificationType
    {
        Deal,
        SuperDeal,
        Catch,

    }
}
