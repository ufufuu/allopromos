using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Admin.EventHandlers 
{
    public class CategoryCreatedEventArgs:EventArgs
    {
        DateTime categoryCreatedOn {get; set; }
    }
    public class StoreCategoryCreatedEventArgs : EventArgs
    {
        DateTime catCreatedOn { get; set; }
    }
    public class OrderPlacedEventArgs : EventArgs
    {
        int orderNumber { get; set; }
        DateTime orderPlaced { get; } //private set; }
    }
}
