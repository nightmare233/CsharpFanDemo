using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataSplider.Models
{
    public class WandoujiaList
    {
        public object state { get; set; }
        public WdjData data { get; set; }
    }

    public class WdjData
    {
        public int currPage { get; set; }
        public string content { get; set; }
    }
}
