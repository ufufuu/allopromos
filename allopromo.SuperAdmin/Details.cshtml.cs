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
    public class DetailsModel : PageModel
    {
        private readonly allopromo.SuperAdmin.Data.AppDbContext _context;

        public DetailsModel(allopromo.SuperAdmin.Data.AppDbContext context)
        {
            _context = context;
        }

        public StoreCategory StoreCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StoreCategory = await _context.StoreCategory.FirstOrDefaultAsync(m => m.storeCatId == id);

            if (StoreCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
