using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Models
{
    public class Evaluation
    {
        public int Id { get; set; }

        [ForeignKey("Parameter")]
        public virtual int ParameterId { get; set; }
        public Parameter Parameter { get; set; }

        public int Mark { get; set; }

        public DateTime AssesmentDate { get; set; }
        public int AssesmentNumber { get; set; }
    }
}
