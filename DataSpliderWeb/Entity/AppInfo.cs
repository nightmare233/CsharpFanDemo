using System;
using System.Collections.Generic;
using System.Text;

namespace DataSpliderWeb.Entity
{
    public class AppInfo
    {
        //AppId
        public string Id { get; set; }
        public string Name { get; set; }
        //开发者
        public string Company { get; set; }
        //开发者所在城市
        public int City_Id { get; set; }
        public int Province_Id { get; set; }
        //Detail详情页URL
        public string URL { get; set; }
        public string InstallCount { get; set; }
        public string Description { get; set; }
        public int Category_Id { get; set; }
        public int SubCategory_Id { get; set; }
    }
}
