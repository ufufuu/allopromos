using allopromo.Common.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Text;

namespace allopromo.Common
{
    public class AppDbContext:DbContext
    {
        public  DbSet<tUsers> Users { get; set; }
    }
}
