﻿using System;
using System.Collections.Generic;

#nullable disable

namespace allopromo.Core.Entities.Identity
{
    public partial class AspNetRoleClaim
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRole Role { get; set; }
    }
}
