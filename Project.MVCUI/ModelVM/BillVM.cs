using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.ModelVM
{
    public class BillVM
    {
        public List<Product> Products { get; set; }

        public List<AppUser> AppUsers { get; set; }

        public List<UserBill> UserBills { get; set; }

        public UserBill userBill { get; set; }
    }
}