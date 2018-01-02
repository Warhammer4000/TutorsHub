using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Others;

namespace DLL.NotificationContext
{
    public class NotificationRepository
    {
        public bool Add(Notification notification)
        {
           
            using (var context = new Context())
            {
                try
                {
                    context.Notifications.Add(notification);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }

        public List<Notification> GetNotifications(string key)
        {
            using (var context = new Context())
            {
                return context.Set<Notification>().Where(r=>r.Key==key).ToList();

            }
        }


    }
}
