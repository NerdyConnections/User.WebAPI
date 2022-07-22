using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.DTO.Common;
using User.Domain.Models;
using User.Domain.Models.Common;

namespace User.Domain.DTO
{
    public  class UserModelDTO:BaseDTOEntity
    {
       
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string Phone { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDTO Department { get; set; }
    }
}
