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
    public class HomeController : Controller
    {
        AppUserRepository _appUser;
        public HomeController()
        {
            _appUser = new AppUserRepository();
            
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AppUserList()
        {
            AppUserVM AVM = new AppUserVM()
            {
                AppUsers = _appUser.GetActives(),
            };

            return View(AVM);
        }

        public ActionResult AppUserAdd()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AppUserAdd(string firstName,string lastName,string address,string eMail)
        {
            if(firstName == "" || lastName == "" || address == "" || eMail == "")
            {
                ViewBag.info = "Please enter informations";

                return View();

            }

            AppUser user = new AppUser()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                EMail = eMail,
            };

            _appUser.Add(user);

            TempData["info"] = "User successfully added";



            return RedirectToAction("AppUserList");
        }

        public ActionResult AppUserUpdate(int id)
        {
            AppUser user = _appUser.Find(id);

            AppUserVM AVM = new AppUserVM()
            {
                AppUser = user,
            };
            return View(AVM);
        }

        [HttpPost]

        public ActionResult AppUserUpdate(string firstName, string lastName, string address, string eMail,int id)
        {
            if (firstName == "" || lastName == "" || address == "" || eMail == "")
            {
                TempData["info"] = " User failed to update,No information can be empty";

                return RedirectToAction("AppUserList");

            }

            AppUser user = new AppUser()
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                EMail = eMail,
            };

            _appUser.Update(user);


            TempData["info"] = "User successfully updated";
            return RedirectToAction("AppUserList");
        }

       public ActionResult AppUserDelete(int id)
        {
            _appUser.Delete(_appUser.Find(id));

            TempData["info"] = "User successfully deleted";

            return RedirectToAction("AppUserList");
        }
    }
}