using System;
namespace allopromo.Core.Abstract
{
    public interface INotifyService

    {
        public bool StoreCreatedEventHandler(object source, EventArgs e)//(string msg, int userId)
        {
            return true;
        }
        bool SendNotification();  
    }
}