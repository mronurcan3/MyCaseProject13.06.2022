using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class AppUser:BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string EMail { get; set; }

        //Relational Properties

        public virtual Bill Bill { get; set; }

        public virtual List<UserBill> UserBills { get; set; }


    }
}
