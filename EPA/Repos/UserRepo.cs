using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPA.Models;

namespace EPA.Repos
{
    interface IUserRepository<User>
    {
        IEnumerable<User> GetUserList();
        Task CreateUser(User user);
        User FindUser(int Id);
        void DeleteUser(int Id);
        Task UpdateUser(UserTable u);
    }
}
