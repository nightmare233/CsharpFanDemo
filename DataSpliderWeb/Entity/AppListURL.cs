using System;
using System.Collections.Generic;
using System.Text;

namespace DataSpliderWeb.Entity
{
    public class AppListURL
    {
        public int Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public string ListURL { get; set; }
        public int Category_Id { get; set; }
        public int SubCategory_Id { get; set; }
        //当前页码
        public int PageIndex { get; set; }
        //Data/Content里面的数据, 这个可不存数据库。
        //public string Content { get; set; }
        //public List<AppInfo> AppInfos { get; set; } = new List<AppInfo>();
    }
}
