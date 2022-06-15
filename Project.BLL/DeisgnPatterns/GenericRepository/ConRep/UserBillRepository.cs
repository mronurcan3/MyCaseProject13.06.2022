using Project.BLL.DeisgnPatterns.GenericRepository.BaseRep;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DeisgnPatterns.GenericRepository.ConRep
{
    public class UserBillRepository: BaseRepository<UserBill>
    {
        
        public UserBillRepository()
        {
            
        }

        public virtual void UpdateMany( UserBill item)
        {

            
            item.Status = Entities.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;

            UserBill toBeUpdated = this.FirstOrDefault(x => x.AppUserID == item.AppUserID && x.BillID == item.BillID);

            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }
    }
}
