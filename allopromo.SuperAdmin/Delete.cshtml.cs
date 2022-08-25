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
    public class DeleteModel : PageModel
    {
        private readonly allopromo.SuperAdmin.Data.AppDbContext _context;

        public DeleteModel(allopromo.SuperAdmin.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StoreCategory = await _context.StoreCategory.FindAsync(id);

            if (StoreCategory != null)
            {
                _context.StoreCategory.Remove(StoreCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
