using CompanyBranchCore.Entities;
using CompanyBranchCore.Interfaces;
using CompanyBranchInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBranchInfrastructure.Repositories
{
    public class BranchRepository : GenericRepository<Branch> , IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context)
        {
        }
    }
}
