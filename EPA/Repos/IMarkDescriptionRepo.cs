using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPA.Repos
{
    interface IMarkDescriptionRepo<MarkDescription>
    {
        IEnumerable<MarkDescription> GetMarkDescriptionList();
    }
}
