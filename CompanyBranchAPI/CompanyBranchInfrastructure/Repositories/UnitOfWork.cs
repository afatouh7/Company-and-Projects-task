using AutoMapper;
using CompanyBranchCore.Interfaces;
using CompanyBranchInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBranchInfrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _contex;
        private readonly IMapper _mapper;

        public ICompanyRepository CompanyRepository { get; }
        public IBranchRepository BranchRepository { get; }
        public UnitOfWork(AppDbContext context, IMapper mapper)
        {
            _contex = context;
            _mapper = mapper;
            BranchRepository = new BranchRepository(_contex);
            CompanyRepository = new CompanyRepository(_contex);
        }

       
    }
}
