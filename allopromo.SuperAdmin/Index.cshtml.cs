using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using allopromo.SuperAdmin.Data;
using allopromo.SuperAdmin.Model;

namespace allopromo.SuperAdmin
{
    public class IndexModel : PageModel
    {
        private readonly allopromo.SuperAdmin.Data.AppDbContext _context;

        public IndexModel(allopromo.SuperAdmin.Data.AppDbContext context)
        {
            _context = context;
        }
        public IList<StoreCategory> StoreCategory { get;set; }
        public async Task OnGetAsync()
        {
            StoreCategory = await _context.StoreCategory.ToListAsync();
        }
    }
}
