using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EPA.Models
{
    public class EpaDbContext : DbContext
    {
        public EpaDbContext()
        {
        }

        public EpaDbContext(DbContextOptions<EpaDbContext> options) : base(options)
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Evaluation> Evaluations {get; set;}
        public DbSet<MarkDescription> MarkDescriptions {get; set;}
        public DbSet<Selection> Selections {get; set;}
        public DbSet<UserEvaluation> UserEvaluations { get; set; }
        public DbSet<Grading> Gradings { get; set; }

    }
}
