using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using allopromo.SuperAdmin.Data;
using allopromo.SuperAdmin.Model;

namespace allopromo.SuperAdmin
{
    public class CreateModel : PageModel
    {
        private readonly allopromo.SuperAdmin.Data.AppDbContext _context;

        public CreateModel(allopromo.SuperAdmin.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StoreCategory StoreCategory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StoreCategory.Add(StoreCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
