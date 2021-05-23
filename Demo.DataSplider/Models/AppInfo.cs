using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataSplider.Models
{
    public class AppInfo
    {
        //AppId
        public string Id { get; set; }
        public string Name { get; set; }
        //开发者
        public string Company { get; set; }
        //开发者所在城市
        public string City { get; set; }
        //Detail详情页URL
        public string URL { get; set; }
        public string InstallCount { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
