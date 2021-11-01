using ReadME.Database;
using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public class NotificationRepo : INotificationRepo
    {

        private readonly DataContext _dataContext;

        public NotificationRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Notification> GetAllNotification(int userId)
        {
            return _dataContext.Notifications.Where(notification => notification.UserId == userId).ToList();
                    // select * from Notification where UserId='12';
        }

        public bool MaskAsRead(int userId)
        {
            List<Notification> result = GetAllNotification(userId);
            result.ForEach(notification => notification.IsNew = false);
            _dataContext.SaveChanges();
            return true;

        }

        public bool Notify(Notification notification)
        {
            
            _dataContext.Notifications.Add(notification);
            _dataContext.SaveChanges();
            return true;
          
            
        }
    }
}
