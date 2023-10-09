using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suls.Services
{
    public interface ISubmissionsService
    {
        void Create(string userId, string problemId, string code);
        void Delete(string id);
    }
}
