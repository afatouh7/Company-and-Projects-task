using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBranchCore.Interfaces
{
    public interface IUnitOfWork
    { 
        public ICompanyRepository CompanyRepository { get; }
        public IBranchRepository BranchRepository { get;  }
    }
}
