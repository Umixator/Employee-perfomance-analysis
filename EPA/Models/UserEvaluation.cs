using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Models
{
    public class UserEvaluation
    {
        public int Id { get; set; }
        [ForeignKey("Evaluation")]
        public virtual int? EvaluationId { get; set; }
        public Evaluation Evaluations { get; set; }

        [ForeignKey("User")]
        public virtual int? UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Assesor")]
        public virtual int? AssesorId { get; set; }
        public User Assesor { get; set; }
    }
}
