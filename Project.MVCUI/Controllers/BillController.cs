using Project.BLL.DeisgnPatterns.GenericRepository.ConRep;
using Project.Entities.Models;
using Project.MVCUI.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class BillController : Controller
    {
        ProductRepository _product;

        AppUserRepository _appUser;

        BillRepository _bill;

        UserBillRepository _userBill;

        public BillController()
        {
            _product = new ProductRepository();

            _appUser = new AppUserRepository();

            _bill = new BillRepository();

            _userBill = new UserBillRepository();
        }
        // GET: Bill
        public ActionResult BillAdd()
        {
            BillVM BVM = new BillVM()
            {
                Products = _product.GetActives(),
                AppUsers = _appUser.GetActives(),
            };

            return View(BVM);
        }

        [HttpPost]

        public ActionResult BillAdd(int user,int[] quantity,params string[] product)
        {
            Dictionary<int, int> productQuantities = new Dictionary<int, int>();

            int index = 0;

            for (int i = 0; i < quantity.Length ; i++)
            {
                int currentNumber = quantity[i];
                if(currentNumber != 0)
                {
                    productQuantities.Add(Convert.ToInt32(product[index]), currentNumber);
                    index++;

                }
            }

            Bill bill = new Bill()
            {
                AppUserID = user,
            };

            _bill.Add(bill);

            List<Product> products = new List<Product>();

            decimal totalPrice = 0;

            foreach (KeyValuePair<int,int> item in productQuantities)
            {
                products.Add(_product.Find(item.Key));
                _product.Find(item.Key).Quantity = item.Value;

               

            };

            foreach (Product item in products)
            {
                totalPrice += item.Price * item.Quantity;
            }

    


            UserBill userBill = new UserBill()
            {
                BillID = bill.ID,
                AppUserID = user,
                Products = products,
                TotalPrice = totalPrice,
                AppUser = _appUser.Find(user),
                

            };

            _userBill.Add(userBill);



            return RedirectToAction("BillList");
        }

        public ActionResult BillList()
        {
            BillVM BVM = new BillVM()
            {
                UserBills = _userBill.GetActives()
            };

            return View(BVM);
        }

        public ActionResult BillUpdate(int billID,int AppUserID)
        {
            UserBill userBill = _userBill.FirstOrDefault(x => x.BillID == billID && x.AppUserID == AppUserID);

            BillVM BVM = new BillVM()
            {
                userBill = userBill,
            };

            return View(BVM);
        }

        [HttpPost]

        public ActionResult BillUpdate(int billID,int user, int[] quantity, params string[] product)
        {
            Dictionary<int, int> productQuantities = new Dictionary<int, int>();

            int index = 0;

            for (int i = 0; i < quantity.Length; i++)
            {
                int currentNumber = quantity[i];
                if (currentNumber != 0)
                {
                    productQuantities.Add(Convert.ToInt32(product[index]), currentNumber);
                    index++;

                }
            }

           

            

            List<Product> products = new List<Product>();

            decimal totalPrice = 0;

            foreach (KeyValuePair<int, int> item in productQuantities)
            {
                products.Add(_product.Find(item.Key));
                _product.Find(item.Key).Quantity = item.Value;



            };

            foreach (Product item in products)
            {
                totalPrice += item.Price * item.Quantity;
            }




            UserBill userBill = new UserBill()
            {
                BillID = billID,
                AppUserID = user,
                Products = products,
                TotalPrice = totalPrice,
                AppUser = _appUser.Find(user),


            };

            _userBill.UpdateMany(userBill);


            return RedirectToAction("BillList");
        }

        public ActionResult BillDelete(int billID,int appUserID)
        {
            _userBill.Delete(_userBill.FirstOrDefault(x => x.BillID == billID && x.AppUserID == appUserID));


            return RedirectToAction("BillList");
        }

    }
}