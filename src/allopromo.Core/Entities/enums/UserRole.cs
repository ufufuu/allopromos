using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Entities.enums
{

    public enum Role
    {
        Merchant,
        Admin,
        Client,
    }

    public static class UserRole
    {
        public const string Clients = "Clients";
        public const string Merchants = "Merchants";
        public const string Admin = "Admin";
    }

    internal enum ShoppingCartType
    {
        ShoppingCart = 1,
        WishList = 2,
    }
}
}
