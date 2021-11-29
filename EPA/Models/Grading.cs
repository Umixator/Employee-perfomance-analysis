using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Models
{
    public class Grading
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Selection> Selections { get; set; }
    }
}
