using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataSpliderWeb;
using DataSpliderWeb.Entity;

namespace DataSpliderWeb.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly DataSpliderWeb.MySqlContext _context;

        public DeleteModel(DataSpliderWeb.MySqlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.city.FirstOrDefaultAsync(m => m.id == id);

            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.city.FindAsync(id);

            if (City != null)
            {
                _context.city.Remove(City);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
