using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public interface INotificationRepo
    {
       public bool Notify(Notification notification);

        public bool MaskAsRead(int userId);

       public List<Notification> GetAllNotification(int userId);

    }
}
