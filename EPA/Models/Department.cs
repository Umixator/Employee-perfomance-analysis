using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ShowPreviousEvaluations { get; set; }
        public ICollection<Selection> Selections { get; set; }
    }
}
