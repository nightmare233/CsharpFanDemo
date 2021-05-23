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
    public class IndexModel : PageModel
    {
        private readonly DataSpliderWeb.MySqlContext _context;

        public IndexModel(DataSpliderWeb.MySqlContext context)
        {
            _context = context;
        }

        public IList<City> City { get;set; }

        public async Task OnGetAsync()
        {
            City = await _context.city.ToListAsync();
        }
    }
}
