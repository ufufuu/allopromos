using System;
namespace allopromo.Core.Abstract
{
    public interface INotificationService
    {
        public bool SendNotification();

        public bool StoreCreatedEventHandler(object source, EventArgs e)
        {
            return true;
        }
        public bool StoreCreatedEventHandler(string msg, int userId)
        {
            return true;
        }
    }
}