using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Models
{
    public class GradingTable
    {
        public Grading Grading { get; set; }
        public Parameter Parameter { get; set; }
        public MarkDescription MarkDescription { get; set; }
        public Selection Selection { get; set; }
        public IEnumerable<Selection> Selections { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Grading> Gradings { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }
        public IEnumerable<MarkDescription> MarkDescriptions { get; set; }
    }
}
