using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class UserBillMap:BaseMap<UserBill>
    {
        public UserBillMap()
        {
            Ignore(x => x.ID).HasKey(x => new
            {
                x.AppUserID,
                x.BillID,
            });
        }
    }
}
