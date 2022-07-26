﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Models.Common;

namespace User.Domain.Models
{
    public  class UserModel : BaseEntity
    {

       

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string Phone { get; set; }

        public int DepartmentId { get; set; }

        //Navigation Property

        public Department Department { get; set; }
    }
}
