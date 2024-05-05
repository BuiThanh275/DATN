using BanDongHo.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDongHo.Models
{
    public class ProductAdd
    { 
        public SelectList ProductCategorys { get; set; }
        public SelectList ProductTypes { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }

}