﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Bill:BaseEntity
    {
        public int AppUserID { get; set; }

        //Relational Properties

        public virtual List<AppUser> AppUsers { get; set; }
    }
}
