using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataSplider.Models
{
    public class AppInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string URL { get; set; }
        public string InstallCount { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
