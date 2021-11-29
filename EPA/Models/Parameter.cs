using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Models
{
    public class Parameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Coefficient { get; set; }
        public ICollection<MarkDescription> MarkDescriptions { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
        public ICollection<Selection> Selections { get; set; }
    }
}
