using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.ModelVM
{
    public class AppUserVM
    {
        public AppUser AppUser { get; set; }

        public List<AppUser> AppUsers { get; set; }
    }
}