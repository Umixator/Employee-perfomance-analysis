using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPA.Repos;
using EPA.Models;
using Microsoft.EntityFrameworkCore;

namespace EPA.Services
{
    public class UserService : IUserRepository<User>, IRoleRepository<Role>, IDepartmentRepo<Department>
    {
        private EpaDbContext db;

        public UserService(EpaDbContext _db)
        {
            this.db = _db;
        }
        public IEnumerable<Department> GetDepartmentList()
        {
            return db.Departments;
        }
        public IEnumerable<Role> GetRoleList()
        {
            return db.Roles;
        }
        public User FindUser(int Id)
        {
            return db.Users.Find(Id);
        }
        public async Task CreateUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
        }
        public void DeleteUser(int Id)
        {
            User user = FindUser(Id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public async Task UpdateUser(UserTable u)
        {
            db.Users.Update(u.User);
            await db.SaveChangesAsync();
        }
        public IEnumerable<User> GetUserList()
        {
            return db.Users.Include(x => x.Role).Include(x => x.Status);
        }

    }
}
