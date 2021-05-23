using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataSplider.Models
{
    public class AppList
    {
        public int Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public string ListURL { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public List<AppInfo> AppInfos { get; set; } = new List<AppInfo>();
    }
}
