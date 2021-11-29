using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Models
{
    public class Selection
    {
        public int Id { get; set; }

        [ForeignKey("Grading")]
        public virtual int GradingId { get; set; }
        public Grading Grading { get; set; }

        [ForeignKey("Parameter")]
        public virtual int ParameterId { get; set; }
        public Parameter Parameter { get; set; }

        [ForeignKey("Department")]
        public virtual int DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Role")]
        public virtual int RoleId { get; set; }
        public Role Role { get; set; }

        public int Mark { get; set; }
    }
}
