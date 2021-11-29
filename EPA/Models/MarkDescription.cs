using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Models
{
    public class MarkDescription
    {
        public int Id { get; set; }

        [ForeignKey("Parameter")]
        public virtual int ParameterId { get; set; }
        public Parameter Parameter { get; set; }

        public int Mark { get; set; }
        public string Description { get; set; }
    }
}
