using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class UserBill:BaseEntity
    {
        public int BillID { get; set; }

        public int AppUserID { get; set; }


        public decimal TotalPrice { get; set; }


        //Relational Properties

        public virtual List<Bill> Bills { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual AppUser AppUser { get; set; }


    }
}
