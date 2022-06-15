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
    public class ProductController : Controller
    {
        ProductRepository _product;
        public ProductController()
        {
            _product = new ProductRepository();
        }

        public ActionResult ProductList()
        {
            ProductVM PVM = new ProductVM()
            {
                Products = _product.GetActives(),
            };

            return View(PVM);
        }
        // GET: Product
        public ActionResult ProductAdd()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ProductAdd(string name,string price)
        {
            if(name == "" || price == ""){

                ViewBag.info = "Please enter informations";
                return View();
            }

            Product product = new Product()
            {
                Name = name,
                Price = Convert.ToDecimal(price),
            };

            _product.Add(product);

            TempData["info"] = "The product has been successfully added";
            return RedirectToAction("ProductList");
        }

        public ActionResult ProductUpdate(int id)
        {
            Product product = _product.Find(id);

            ProductVM PVM = new ProductVM()
            {
                Product = product,
            };
            return View(PVM);
        }

        [HttpPost]

        public ActionResult ProductUpdate(string name, string price, int id)
        {
            if (name == "" || price == "")
            {
                TempData["info"] = " product failed to update,No information can be empty";

                return RedirectToAction("ProductList");

            }

            Product product = new Product()
            {
                ID = id,
                Name = name,
                Price = Convert.ToDecimal(price),
                
            };

            _product.Update(product);


            TempData["info"] = "Product successfully updated";
            return RedirectToAction("ProductList");
        }

        public ActionResult ProductDelete(int id)
        {
            _product.Delete(_product.Find(id));

            TempData["info"] = "Product successfully deleted";

            return RedirectToAction("ProductList");
        }

    }
}