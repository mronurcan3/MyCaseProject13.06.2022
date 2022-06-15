using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }


        //Relational Properties

        public virtual UserBill UserBill { get; set; }
        
    }
}
