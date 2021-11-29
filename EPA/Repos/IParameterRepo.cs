using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Repos
{
    interface IParameterRepo<Parameter>
    {
        IEnumerable<Parameter> GetParameterList();
    }
}
