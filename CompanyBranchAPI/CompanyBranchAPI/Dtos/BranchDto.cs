namespace CompanyBranchAPI.Dtos
{
    public class BranchDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public int CompanyId { get; set; }
    }
    public class UpdateBranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public int CompanyId { get; set; }
    }
    public class BranchsDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public int CompanyId { get; set; } 
        public CompanyDto Company { get; set; }
    }

}
