using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPA.Models
{
    public class User
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        [ForeignKey("Role")]
        public virtual int RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("Status")]
        public virtual int StatusId { get; set; }
        public Status Status { get; set; }

        [ForeignKey("Department")]
        public virtual int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int? SupervisorId { get; set; }
    }
}
