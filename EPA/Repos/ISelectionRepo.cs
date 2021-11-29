using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPA.Models;

namespace EPA.Repos
{
    interface ISelectionRepo<Selection>
    {
        IEnumerable<Selection> GetSelectionList();
        Task CreateSelection(Grading grading, IEnumerable<Selection> selections);
        IEnumerable<Selection> FindSelection(int Id);
        void DeleteSelection(int Id);
        Task UpdateSelection(GradingTable g);
    }
}
