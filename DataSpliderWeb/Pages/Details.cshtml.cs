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
    public class DetailsModel : PageModel
    {
        private readonly DataSpliderWeb.MySqlContext _context;

        public DetailsModel(DataSpliderWeb.MySqlContext context)
        {
            _context = context;
        }

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
    }
}
