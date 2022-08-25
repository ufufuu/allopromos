using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.ValueObjects
{
    public class Status
    {
        //public int Active=1,
        //public int Inactive=0,
    }
    public enum StoreStatus//: Status ? inheritance from Status
    {
        Active=1,
        Inactive=0,
    }
}
