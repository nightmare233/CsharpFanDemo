using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataSpliderWeb.Entity
{
    public class City
    {
        public string city { get; set; }

        [Key]
        public int city_id { get; set; }
        
       public int country_id { get; set; }

        public DateTime last_update { get; set; }
    }
}
