using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Entity.Others
{
    public enum Notificationtype { Message,ScheduleProposiotion}

    public class Notification
    {
        [Key]
        public int Serial { get; set; }
        public string Key { get; set; }
        public string Message { get; set; }
        [AllowHtml]
        public string ActionLink { get; set; }
        public bool IsChecked { get; set; }
      
        public Notificationtype Notificationtype { get; set; }
        public string NotificationData { get; set; }
        

    }
}
