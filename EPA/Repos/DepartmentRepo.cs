using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPA.Models;

namespace EPA.Repos
{
    interface IDepartmentRepo<Department>
    {
        IEnumerable<Department> GetDepartmentList();
    }
}
