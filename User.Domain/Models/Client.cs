using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Models
{
    public  class Client
    {

         public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
