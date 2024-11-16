using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBranchCore.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; } 
    }
}
