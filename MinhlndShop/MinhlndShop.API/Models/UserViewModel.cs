using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhlndShop.API.Models
{
    public class UserViewModel
    {
        public int Id { get; set; } 
        //public string UserName { get; set; } 
        public string Password { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Address { get; set; } 
        public string Phone { get; set; }
        public int Role { get; set; }
    }
}
