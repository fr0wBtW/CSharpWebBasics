using Suls.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suls.Services
{
    public interface IProblemsService
    {
        void Create(string name, ushort points);

        IEnumerable<HomePageProblemViewModel> GetAll();

        string GetNameById(string id);
        ProblemViewModel GetById(string id);
    }
}
