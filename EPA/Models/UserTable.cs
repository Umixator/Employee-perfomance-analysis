using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Models
{
    public class UserTable
    {
        public IEnumerable<User> Users { get; set; }
        public User User { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
