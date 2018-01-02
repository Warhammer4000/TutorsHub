using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.NotificationRepository;
using Entity.Others;

namespace TutorsHub.Application.Models
{
    public class NotificationViewModel
    {
        public List<Notification> Notifications { get;  }

        public NotificationViewModel(string key)
        {
            Notifications=new NotificationService().GetNotifications(key);
        }
    }
}