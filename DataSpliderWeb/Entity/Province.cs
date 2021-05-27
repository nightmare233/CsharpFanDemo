using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataSpliderWeb.Entity
{
    public class Province
    {
        public string name { get; set; }

        [Key]
        public int id { get; set; }
         
    }
}
