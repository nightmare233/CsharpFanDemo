using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataSpliderWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MySqlContext _db;
        public IndexModel(ILogger<IndexModel> logger, MySqlContext dBContext)
        {
            _logger = logger;
            _db = dBContext;
        }

        public void OnGet()
        {
            var list = _db.city.ToList();
        }
    }
}
