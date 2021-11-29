using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPA.Repos;
using EPA.Models;
using Microsoft.EntityFrameworkCore;

namespace EPA.Services
{
    public class GradingService : IGradingRepo<Grading>, IMarkDescriptionRepo<MarkDescription>, IParameterRepo<Parameter>, ISelectionRepo<Selection>, IDepartmentRepo<Department>
    {
        private EpaDbContext db;

        public GradingService(EpaDbContext _db)
        {
            this.db = _db;
        }
        public IEnumerable<Grading> GetGradingList()
        {
            return db.Gradings;
        }
        public IEnumerable<Department> GetDepartmentList()
        {
            return db.Departments;
        }
        public IEnumerable<MarkDescription> GetMarkDescriptionList()
        {
            return db.MarkDescriptions;
        }
        public IEnumerable<Parameter> GetParameterList()
        {
            return db.Parameters.Include(d => d.MarkDescriptions);
        }
        public IEnumerable<Selection> GetSelectionList()
        {
            return db.Selections.Include(x => x.Grading).Include(x => x.Parameter).Include(x => x.Department).Include(x => x.Role);
        }
        public IEnumerable<Selection> FindSelection(int Id)
        {
            return (from s in db.Selections where s.GradingId == Id select s);
        }
        public void DeleteSelection(int Id)
        {
            IEnumerable<Selection> selections = FindSelection(Id);
            foreach (var sel in selections)
            {
                if (sel != null)
                {
                    db.Selections.Remove(sel);
                    db.SaveChanges();
                }
            }

        }
        public async Task UpdateSelection(GradingTable g)
        {
            db.Selections.Update(g.Selection);  
            await db.SaveChangesAsync();
        }
        public async Task CreateSelection(Grading grading, IEnumerable<Selection> selections)
        {
            db.Gradings.Add(grading);
            foreach(var sel in selections)
            {
                db.Selections.Add(sel);
            }
            await db.SaveChangesAsync();
        }
        public async Task CreateParameter(Parameter parameter, IEnumerable<MarkDescription> markDescriptions)
        {
            db.Database.OpenConnection();
            db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.MarkDescriptions ON;");
            db.SaveChanges();
            db.Parameters.Add(parameter);
            int maxId = db.MarkDescriptions.Select(x => x.Id).Max() + 1;
            foreach (var description in markDescriptions)
            {
                description.Id = maxId;
                maxId++;
                description.ParameterId = db.Parameters.OrderBy(x => x.Id).Last().Id;
                db.MarkDescriptions.Add(description);
            }
            await db.SaveChangesAsync();
            db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.MarkDescriptions OFF;");
        }

    }
}
