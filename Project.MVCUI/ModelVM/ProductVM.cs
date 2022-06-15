using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.ModelVM
{
    public class ProductVM
    {
        public List<Product> Products { get; set; }

        public Product Product { get; set; }
    }
}