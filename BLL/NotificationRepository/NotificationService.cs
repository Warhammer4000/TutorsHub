using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Others;

namespace BLL.NotificationRepository
{
    public class NotificationService
    {
        public bool Add(Notification notification) =>
            new DLL.NotificationContext.NotificationRepository().Add(notification);

        public List<Notification> GetNotifications(string key) =>
            new DLL.NotificationContext.NotificationRepository().GetNotifications(key);
    }
}
